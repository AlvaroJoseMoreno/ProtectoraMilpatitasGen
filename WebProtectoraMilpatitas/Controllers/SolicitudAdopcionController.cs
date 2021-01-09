using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CP.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Assemblers;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Controllers
{
    [Authorize]
    public class SolicitudAdopcionController : BasicController
    {
        public ActionResult Index(int? page, string sortOrder, string nameSearch, string usuSearch, string aniSearch, string dateSearch, string estSearch)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            SessionInitialize();

            SolicitudAdopcionCAD solCAD = new SolicitudAdopcionCAD(session);
            SolicitudAdopcionCEN solCEN = new SolicitudAdopcionCEN(solCAD);

            IList<SolicitudAdopcionEN> solsEN = solCEN.Dame_Todas(0, -1).Where(s=>s.Estado!=ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.rechazado).ToList();

            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.UsuSort = String.IsNullOrEmpty(sortOrder) ? "usu_desc" : "";
            ViewBag.AniSort = String.IsNullOrEmpty(sortOrder) ? "ani_desc" : "";
            ViewBag.DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.EstSort = String.IsNullOrEmpty(sortOrder) ? "est_desc" : "";

            if (!String.IsNullOrEmpty(nameSearch))
            {
                solsEN = solsEN.Where(s => s.Nombre.Contains(nameSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(usuSearch))
            {
                solsEN = solsEN.Where(s => s.Usuario.Nombre.Contains(usuSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(aniSearch))
            {
                solsEN = solsEN.Where(s => s.Animal.Nombre.Contains(aniSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(estSearch))
            {
                solsEN = solsEN.Where(s => s.Estado.ToString().Contains(estSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(dateSearch))
            {
                solsEN = solsEN.Where(s => s.FechaSolicitud.ToString().Contains(dateSearch)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    solsEN = solsEN.OrderByDescending(s => s.Nombre).ToList();
                    break;
                case "usu_desc":
                    solsEN = solsEN.OrderByDescending(s => s.Usuario.Nombre).ToList();
                    break;
                case "ani_desc":
                    solsEN = solsEN.OrderByDescending(s => s.Animal.Nombre).ToList();
                    break;
                case "Date":
                    solsEN = solsEN.OrderBy(s => s.FechaSolicitud).ToList();
                    break;
                case "date_desc":
                    solsEN = solsEN.OrderByDescending(s => s.FechaSolicitud).ToList();
                    break;
                case "est_desc":
                    solsEN = solsEN.OrderByDescending(s => s.Estado).ToList();
                    break;
                default:
                    solsEN = solsEN.OrderBy(s => s.Nombre).ToList();
                    break;
            }

            IEnumerable<SolicitudAdopcionViewModel> listaSolicitudes = new SolicitudAdopcionAssembler().ConvertListENToModel(solsEN).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaSolicitudes.ToPagedList(pageNumber, pageSize));
        }

        // GET: SolicitudAdopcion/Details/5
        public ActionResult Details(int id)
        {
            SolicitudAdopcionViewModel sol = null;

            SessionInitialize();

            SolicitudAdopcionEN solEN = new SolicitudAdopcionCAD(session).Ver_Solicitud(id);

            sol = new SolicitudAdopcionAssembler().ConvertENToModelUI(solEN);

            SessionClose();

            return View(sol);
        }

        // GET: SolicitudAdopcion/Create
        public ActionResult Create()
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            IList<UsuarioEN> listausuarios = new UsuarioCEN().Dame_Todos(0, -1);
            IList<SelectListItem> usuariositems = new List<SelectListItem>();

            foreach (UsuarioEN usu in listausuarios)
            {
                usuariositems.Add(new SelectListItem { Text = usu.Nombre, Value = usu.Email });

            }

            ViewData["idUsuario"] = usuariositems;

            IList<AnimalEN> listaAnimales = new AnimalCEN().Dame_Todos(0, -1);
            IList<SelectListItem> animalesItems = new List<SelectListItem>();

            foreach (AnimalEN ani in listaAnimales)
            {
                animalesItems.Add(new SelectListItem { Text = ani.Nombre, Value = ani.Id.ToString() });
            }

            ViewData["idAnimal"] = animalesItems;

            return View();
        }

        // POST: SolicitudAdopcion/Create
        [HttpPost]
        public ActionResult Create(SolicitudAdopcionViewModel sol)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            try
            {
                // TODO: Add insert logic here
                SolicitudAdopcionCEN soliCEN = new SolicitudAdopcionCEN();

                int idsol=soliCEN.Nuevo(sol.idUsuario, sol.idAnimal, DateTime.Today);

                SolicitudAdopcionCP solCP = new SolicitudAdopcionCP();
                solCP.Actualizar_Estado(idsol, ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.enEspera);

                TempData["mensajeModal"] = "¡Enhorabuena! Has creado una solicitud";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitudAdopcion/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            SolicitudAdopcionViewModel sol = null;

            SessionInitialize();

            SolicitudAdopcionEN solEN = new SolicitudAdopcionCAD(session).Ver_Solicitud(id);

            sol = new SolicitudAdopcionAssembler().ConvertENToModelUI(solEN);

            SessionClose();

            return View(sol);
           
        }

        // POST: SolicitudAdopcion/Edit/5
        [HttpPost]
        public ActionResult Edit(SolicitudAdopcionViewModel sol)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            try
            {
                // TODO: Add update logic here
               
                SolicitudAdopcionCEN solCEN = new SolicitudAdopcionCEN();

                solCEN.Rellenar_Solicitud(sol.Id, sol.Nombre, sol.AnimalesAcargo,
                    sol.AmbienteConvivencia, sol.TiempoLibre, sol.TodosAcuerdo, sol.MotivosAdopcion);

                TempData["mensajeModal"] = "¡Enhorabuena! Has modificado la información de la solicitud";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ActualizarEstado(int id)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            SolicitudAdopcionViewModel sol = null;

            SessionInitialize();

            SolicitudAdopcionEN solEN = new SolicitudAdopcionCAD(session).Ver_Solicitud(id);

            sol = new SolicitudAdopcionAssembler().ConvertENToModelUI(solEN);

            SessionClose();

            return View(sol);

        }

        // POST: SolicitudAdopcion/Edit/5
        [HttpPost]
        public ActionResult ActualizarEstado(SolicitudAdopcionViewModel sol)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            try
            {
                // TODO: Add update logic here

                SolicitudAdopcionCP solCP = new SolicitudAdopcionCP();

                solCP.Actualizar_Estado(sol.Id, sol.Estado);

                TempData["mensajeModal"] = "Se ha actualizado el estado de la solicitud con exito";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Encuesta(int id)
        {

            TempData["idAni"] = id;
            return View();

        }

        // POST: SolicitudAdopcion/Edit/5
        [HttpPost]
        public ActionResult Encuesta(SolicitudAdopcionViewModel sol)
        {
            try
            {
                // TODO: Add insert logic here

                SolicitudAdopcionCEN soliCEN = new SolicitudAdopcionCEN();
                SessionInitialize();
                UsuarioEN usuen = ((UsuarioEN)Session["Usuario"]);
                int idAni = (int)TempData["idAni"];
               int id= soliCEN.Nuevo(usuen.Email,idAni , DateTime.Today);

                soliCEN.Rellenar_Solicitud(id,usuen.Nombre, sol.AnimalesAcargo, sol.AmbienteConvivencia, sol.TiempoLibre, sol.TodosAcuerdo, sol.MotivosAdopcion);
                SolicitudAdopcionCP soliCP = new SolicitudAdopcionCP();
                soliCP.Actualizar_Estado(id,ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.enEspera);
                SessionClose();
                TempData["mensajeModal"] = "¡Enhorabuena! Tu solicitud de adopción esta en tramite";
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ObtenerSolicitudUsuario(string email, int? page, string sortOrder, string nameSearch, string usuSearch, string aniSearch, string dateSearch, string estSearch)
        {
            SessionInitialize();

            SolicitudAdopcionCAD solCAD = new SolicitudAdopcionCAD(session);
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            SolicitudAdopcionCEN solCEN = new SolicitudAdopcionCEN(solCAD);

            IList<SolicitudAdopcionEN> listaSolEN = solCEN.Obtener_Solicitud_Usuario(email).Where(s => s.Estado != ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoAdopcionEnum.rechazado).ToList();

            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.UsuSort = String.IsNullOrEmpty(sortOrder) ? "usu_desc" : "";
            ViewBag.AniSort = String.IsNullOrEmpty(sortOrder) ? "ani_desc" : "";
            ViewBag.DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.EstSort = String.IsNullOrEmpty(sortOrder) ? "est_desc" : "";

            if (!String.IsNullOrEmpty(nameSearch))
            {
                listaSolEN = listaSolEN.Where(s => s.Nombre.Contains(nameSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(usuSearch))
            {
                listaSolEN = listaSolEN.Where(s => s.Usuario.Nombre.Contains(usuSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(aniSearch))
            {
                listaSolEN = listaSolEN.Where(s => s.Animal.Nombre.Contains(aniSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(estSearch))
            {
                listaSolEN = listaSolEN.Where(s => s.Estado.ToString().Contains(estSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(dateSearch))
            {
                listaSolEN = listaSolEN.Where(s => s.FechaSolicitud.ToString().Contains(dateSearch)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    listaSolEN = listaSolEN.OrderByDescending(s => s.Nombre).ToList();
                    break;
                case "usu_desc":
                    listaSolEN = listaSolEN.OrderByDescending(s => s.Usuario.Nombre).ToList();
                    break;
                case "ani_desc":
                    listaSolEN = listaSolEN.OrderByDescending(s => s.Animal.Nombre).ToList();
                    break;
                case "Date":
                    listaSolEN = listaSolEN.OrderBy(s => s.FechaSolicitud).ToList();
                    break;
                case "date_desc":
                    listaSolEN = listaSolEN.OrderByDescending(s => s.FechaSolicitud).ToList();
                    break;
                case "est_desc":
                    listaSolEN = listaSolEN.OrderByDescending(s => s.Estado).ToList();
                    break;
                default:
                    listaSolEN = listaSolEN.OrderBy(s => s.Nombre).ToList();
                    break;
            }

            IEnumerable<SolicitudAdopcionViewModel> listaSol = new SolicitudAdopcionAssembler().ConvertListENToModel(listaSolEN).ToList();

            UsuarioEN usuEN = usuCAD.Dame_Por_Email(email);

            ViewData["idUsuario"] = email;

            if (usuEN != null)
            {
                ViewData["NombreUsuario"] = usuEN.Nombre;
            }

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaSol.ToPagedList(pageNumber, pageSize));
        }

        // GET: SolicitudAdopcion/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            SessionInitialize();
            SolicitudAdopcionCAD solCad = new SolicitudAdopcionCAD(session);
            SolicitudAdopcionCEN soliCEN = new SolicitudAdopcionCEN(solCad);
            ViewData["IdSol"] = id;
            ViewData["NombreSol"] = soliCEN.Ver_Solicitud(id).Nombre;

            SessionClose();
            return View();
        }

        // POST: SolicitudAdopcion/Delete/5
        [HttpPost]
        public ActionResult Delete(SolicitudAdopcionViewModel sol, FormCollection collection)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            try
            {
                // TODO: Add delete logic here

                SolicitudAdopcionCEN solCEN = new SolicitudAdopcionCEN();
               
                solCEN.Eliminar(sol.Id);

                TempData["mensajeModal"] = "Has eliminado la solicitud";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModal"] = "Ha habido un error al eliminar la solicitud";
                return View();
            }
        }

        public ActionResult AceptarSolicitud (int idSol, string idUsu, string idAni)
        {
            

            SessionInitialize();

            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
            UsuarioEN usuEN = usuCEN.Dame_Por_Email(idUsu);

            ViewData["idSol"] = idSol;
            ViewData["idUsu"] = usuEN.Nombre;
            ViewData["idAni"] = idAni;

            SessionClose();
            

            return View();
        }

        [HttpPost]
        public ActionResult AceptarSolicitud (int idSol, string idUsu, SolicitudAdopcionViewModel sol)
        {
            try
            {
                // TODO: Add insert logic here
                //   filename =" + filename;
                SessionInitialize();

                SolicitudAdopcionCAD solCAD = new SolicitudAdopcionCAD(session);
                SolicitudAdopcionCP solCP = new SolicitudAdopcionCP();

                string resultado=solCP.Aceptar_Solicitud(idSol, idUsu);

                SessionClose();

                TempData["mensajeModal"] = "¡Solicitud Aceptada!";
                return RedirectToAction("Index"); //mostrar mensaje modal

            }
            catch
            {
                return View();
            }
        }

        public ActionResult RechazarSolicitud(int idSol, string idUsu, string idAni)
        {


            SessionInitialize();

            UsuarioCAD usuCAD = new UsuarioCAD(session);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCAD);
            UsuarioEN usuEN = usuCEN.Dame_Por_Email(idUsu);

            ViewData["idSol"] = idSol;
            ViewData["idUsu"] = usuEN.Nombre;
            ViewData["idAni"] = idAni;

            SessionClose();


            return View();
        }

        [HttpPost]
        public ActionResult RechazarSolicitud(int idSol, string idUsu, SolicitudAdopcionViewModel sol)
        {
            try
            {
                // TODO: Add insert logic here
                //   filename =" + filename;
                SessionInitialize();

                SolicitudAdopcionCAD solCAD = new SolicitudAdopcionCAD(session);
                SolicitudAdopcionCP solCP = new SolicitudAdopcionCP();

                string resultado = solCP.Rechazar_Solicitud(idSol, idUsu);

                SessionClose();
                TempData["mensajeModal"] = "Solicitud de adopción rechazada";
                return RedirectToAction("Index"); //mostrar mensaje modal

            }
            catch
            {
                return View();
            }
        }

        public ActionResult RechazarTodasSolicitud()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RechazarTodasSolicitud(SolicitudAdopcionViewModel sol)
        {
            try
            {
                // TODO: Add insert logic here
                //   filename =" + filename;
                SessionInitialize();

                SolicitudAdopcionCAD solCAD = new SolicitudAdopcionCAD(session);
                SolicitudAdopcionCP solCP = new SolicitudAdopcionCP();
                SolicitudAdopcionCEN solCEN = new SolicitudAdopcionCEN(solCAD);

                IList<SolicitudAdopcionEN> sols = solCEN.Dame_Todas(0,-1);

                string[] resultados = new string[sols.Count];
                int i = 0;

                foreach (SolicitudAdopcionEN soli in sols)
                {
                    resultados[i] = solCP.Rechazar_Solicitud(soli.Id, soli.Usuario.Email);

                    i = i + 1;
                }

                SessionClose();
                TempData["mensajeModal"] = "Todas las solicitudes han sido rechazadas";
                return RedirectToAction("Index"); //mostrar mensaje modal

            }
            catch
            {
                return View();
            }
        }
    }
}
