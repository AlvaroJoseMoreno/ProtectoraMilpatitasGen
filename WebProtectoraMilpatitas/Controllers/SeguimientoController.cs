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
    public class SeguimientoController : BasicController
    {
        // GET: Seguimiento
        public ActionResult Index(int? page, string sortOrder, string usuSearch, string aniSearch, string dateSearch, string estSearch)
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

            SeguimientoCAD segCAD = new SeguimientoCAD(session);
            SeguimientoCEN segCEN = new SeguimientoCEN(segCAD);

            IList<SeguimientoEN> segEN = segCEN.Dame_Todos(0, -1);

            ViewBag.UsuSort = String.IsNullOrEmpty(sortOrder) ? "usu_desc" : "";
            ViewBag.AniSort = String.IsNullOrEmpty(sortOrder) ? "ani_desc" : "";
            ViewBag.DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.EstSort = String.IsNullOrEmpty(sortOrder) ? "est_desc" : "";


            if (!String.IsNullOrEmpty(usuSearch))
            {
                segEN = segEN.Where(s => s.Usuario.Nombre.Contains(usuSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(aniSearch))
            {
                segEN = segEN.Where(s => s.Animal.Nombre.Contains(aniSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(estSearch))
            {
                segEN = segEN.Where(s => s.Estado.ToString().Contains(estSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(dateSearch))
            {
                segEN = segEN.Where(s => s.Fecha.ToString().Contains(dateSearch)).ToList();
            }

            switch (sortOrder)
            {
                case "usu_desc":
                    segEN = segEN.OrderByDescending(s => s.Usuario.Nombre).ToList();
                    break;
                case "ani_desc":
                    segEN = segEN.OrderByDescending(s => s.Animal.Nombre).ToList();
                    break;
                case "Date":
                    segEN = segEN.OrderBy(s => s.Fecha).ToList();
                    break;
                case "date_desc":
                    segEN = segEN.OrderByDescending(s => s.Fecha).ToList();
                    break;
                case "est_desc":
                    segEN = segEN.OrderByDescending(s => s.Estado).ToList();
                    break;
                default:
                    segEN = segEN.OrderBy(s => s.Usuario.Nombre).ToList();
                    break;
            }

            IEnumerable<SeguimientoViewModel> listaSeguimiento = new SeguimientoAssembler().ConvertListENToModel(segEN).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaSeguimiento.ToPagedList(pageNumber, pageSize));
        }
        //santi te quiero
        // GET: Seguimiento/Details/5
        public ActionResult Details(int id)
        {
            SeguimientoViewModel seg = null;

            SessionInitialize();

            SeguimientoEN segEn = new SeguimientoCAD(session).ReadOIDDefault(id);

            seg = new SeguimientoAssembler().ConvertENToModelUI(segEn);

            SessionClose();

            return View(seg);
        }

        // GET: Seguimiento/Create
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

            IList<UsuarioEN> listaUsu = new UsuarioCEN().Dame_Todos(0, -1);
            IList<SelectListItem> UsuarioSel = new List<SelectListItem>();

            foreach( UsuarioEN us in listaUsu)
            {
                UsuarioSel.Add(new SelectListItem { Text= us.Nombre, Value=us.Email});
            }
            ViewData["Usuario"] = UsuarioSel;

            IList<AnimalEN> listaAni = new AnimalCEN().Dame_Todos(0, -1);
            IList<SelectListItem> AniSel = new List<SelectListItem>();

            foreach (AnimalEN an in listaAni)
            {
                AniSel.Add(new SelectListItem { Text = an.Nombre, Value = an.Id.ToString() });
            }
            ViewData["Animal"] = AniSel;

            IList<ContratoAdopcionEN> listaSol = new ContratoAdopcionCEN().Dame_Todos(0, -1);
            IList<SelectListItem> SolSel = new List<SelectListItem>();

            foreach (ContratoAdopcionEN sol in listaSol)
            {
                SolSel.Add(new SelectListItem { Text = sol.Nombre, Value = sol.Id.ToString() });
            }
            ViewData["Contrato"] = SolSel;
            return View();
        }

        // POST: Seguimiento/Create
        [HttpPost]
        public ActionResult Create(SeguimientoViewModel segui)
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
                SeguimientoCEN segCEN = new SeguimientoCEN();
                segCEN.Nuevo(segui.Usuario, segui.Animal,segui.Contrato );

                TempData["mensajeModalSeguimiento"] = "Seguimiento creado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalSeguimiento"] = "Ha habido un error al crear el seguimiento";
                return RedirectToAction("Index");
            }
        }

        // GET: Seguimiento/Edit/5
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

            SeguimientoViewModel seg = null;

            SessionInitialize();

            SeguimientoEN segEn = new SeguimientoCAD(session).Dame_Por_Id(id);
            
            seg = new SeguimientoAssembler().ConvertENToModelUI(segEn);

            SessionClose();

            return View(seg);
        }

        // POST: Seguimiento/Edit/5
        [HttpPost]
        public ActionResult Edit(SeguimientoViewModel segui)
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
                SeguimientoCEN segCEN = new SeguimientoCEN();

                segCEN.Modificar(segui.Id, segui.Fecha, segui.Descripcion);


                TempData["mensajeModalSeguimiento"] = "Seguimiento editado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalSeguimiento"] = "Ha habido un error al editar el seguimiento";
                return RedirectToAction("Index");
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

            SeguimientoViewModel seg = null;

            SessionInitialize();


            SeguimientoEN segEN = new SeguimientoCAD(session).Dame_Por_Id(id);

            seg = new SeguimientoAssembler().ConvertENToModelUI(segEN);

            SessionClose();

            return View(seg);

        }

        [HttpPost]
        public ActionResult ActualizarEstado(SeguimientoViewModel seg)
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
                SeguimientoCP segCP = new SeguimientoCP();
                segCP.Actualizar_Estado(seg.Id, seg.Estado);

                TempData["mensajeModalSeguimiento"] = "El estado del seguimiento se ha actualizado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalSeguimiento"] = "Ha habido un error al actualizar el estado del seguimiento";
                return RedirectToAction("Index");
            }
        }

        public ActionResult ObtenerSeguimientoUsuario(string email, int? page, string sortOrder, string usuSearch, string aniSearch, string dateSearch, string estSearch)
        {
            SessionInitialize();

            SeguimientoCAD segCAD = new SeguimientoCAD(session);
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            SeguimientoCEN segCEN = new SeguimientoCEN(segCAD);

            IList<SeguimientoEN> listaSolEN = segCEN.Obtener_Seguimiento_Usuario(email);

            ViewBag.UsuSort = String.IsNullOrEmpty(sortOrder) ? "usu_desc" : "";
            ViewBag.AniSort = String.IsNullOrEmpty(sortOrder) ? "ani_desc" : "";
            ViewBag.DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.EstSort = String.IsNullOrEmpty(sortOrder) ? "est_desc" : "";


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
                listaSolEN = listaSolEN.Where(s => s.Fecha.ToString().Contains(dateSearch)).ToList();
            }

            switch (sortOrder)
            {
                case "usu_desc":
                    listaSolEN = listaSolEN.OrderByDescending(s => s.Usuario.Nombre).ToList();
                    break;
                case "ani_desc":
                    listaSolEN = listaSolEN.OrderByDescending(s => s.Animal.Nombre).ToList();
                    break;
                case "Date":
                    listaSolEN = listaSolEN.OrderBy(s => s.Fecha).ToList();
                    break;
                case "date_desc":
                    listaSolEN = listaSolEN.OrderByDescending(s => s.Fecha).ToList();
                    break;
                case "est_desc":
                    listaSolEN = listaSolEN.OrderByDescending(s => s.Estado).ToList();
                    break;
                default:
                    listaSolEN = listaSolEN.OrderBy(s => s.Usuario.Nombre).ToList();
                    break;
            }

            IEnumerable<SeguimientoViewModel> listaSeg = new SeguimientoAssembler().ConvertListENToModel(listaSolEN).ToList();

            UsuarioEN usuEN = usuCAD.Dame_Por_Email(email);

            ViewData["idUsuario"] = email;

            if (usuEN != null)
            {
                ViewData["NombreUsuario"] = usuEN.Nombre;
            }


            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaSeg.ToPagedList(pageNumber, pageSize));
        }

        // GET: Seguimiento/Delete/5
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
            SeguimientoCAD segCad = new SeguimientoCAD(session);
            SeguimientoCEN seguiCEN = new SeguimientoCEN(segCad);
            ViewData["IdSeg"] = id;
            ViewData["NombreSeg"] = seguiCEN.Dame_Por_Id(id).Usuario.Nombre;

            SessionClose();
            return View();
        }

        // POST: Seguimiento/Delete/5
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

                SeguimientoCEN segui = new SeguimientoCEN();
                segui.Eliminar(id);

                TempData["mensajeModalSeguimiento"] = "Seguimiento eliminado correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalSeguimiento"] = "Ha habido un error al eliminar el seguimiento";
                return RedirectToAction("Index");
            }
        }
    }
}
