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
        public ActionResult Index(int? page)
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

            IList<SolicitudAdopcionEN> solsEN = solCEN.Dame_Todas(0, -1);

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

                soliCEN.Nuevo(sol.idUsuario, sol.idAnimal, DateTime.Today);

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
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ObtenerSolicitudUsuario(string email, int? page)
        {
            SessionInitialize();

            SolicitudAdopcionCAD solCAD = new SolicitudAdopcionCAD(session);
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            SolicitudAdopcionCEN solCEN = new SolicitudAdopcionCEN(solCAD);

            IList<SolicitudAdopcionEN> listaSolEN = solCEN.Obtener_Solicitud_Usuario(email);

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
        public ActionResult Delete(int id, FormCollection collection)
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
               
                solCEN.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
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

                return RedirectToAction("Index"); //mostrar mensaje modal

            }
            catch
            {
                return View();
            }
        }
    }
}
