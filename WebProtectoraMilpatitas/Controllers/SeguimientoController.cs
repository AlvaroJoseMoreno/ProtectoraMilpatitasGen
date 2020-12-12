using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Index()
        {
            SessionInitialize();

            SeguimientoCAD segCAD = new SeguimientoCAD(session);
            SeguimientoCEN segCEN = new SeguimientoCEN(segCAD);

            IList<SeguimientoEN> segEN = segCEN.Dame_Todos(0, -1);
           

            IEnumerable<SeguimientoViewModel> listaSeguimiento = new SeguimientoAssembler().ConvertListENToModel(segEN).ToList();

            SessionClose();

            return View(listaSeguimiento);
        }

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
            try
            {
                // TODO: Add insert logic here
                SeguimientoCEN segCEN = new SeguimientoCEN();
                segCEN.Nuevo(segui.Usuario, segui.Animal,segui.Contrato );
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Seguimiento/Edit/5
        public ActionResult Edit(int id)
        {
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
            try
            {
                // TODO: Add update logic here
                SeguimientoCEN segCEN = new SeguimientoCEN();

                segCEN.Modificar(segui.Id, segui.fecha);
            

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ActualizarEstado(int id)
        {
            SeguimientoViewModel seg = null;

            SessionInitialize();


            SeguimientoEN segEN = new SeguimientoCAD(session).Dame_Por_Id(id);

            seg = new SeguimientoAssembler().ConvertENToModelUI(segEN);

            SessionClose();

            return View(seg);

        }

        // POST: SolicitudAdopcion/Edit/5
        [HttpPost]
        public ActionResult ActualizarEstado(SeguimientoViewModel seg)
        {
            try
            {
                // TODO: Add update logic here

                SeguimientoCP segCP = new SeguimientoCP();

                segCP.Actualizar_Estado(seg.Id,seg.Estado);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ObtenerSeguimientoUsuario (string  email)
        {
            SeguimientoViewModel seg = null;

            SessionInitialize();
            SeguimientoCAD segCAD = new SeguimientoCAD();

       //     SeguimientoEN segEN = new SeguimientoCAD.Dame_Por_Id(email);

        //    seg = new SeguimientoAssembler().ConvertENToModelUI(segEN);

            SessionClose();

            return View(seg);

        }

        // POST: SolicitudAdopcion/Edit/5
        [HttpPost]
        public ActionResult ObtenerSeguimientoUsuario (SeguimientoViewModel seg)
        {
            try
            {
                // TODO: Add update logic here

                SeguimientoCP segCP = new SeguimientoCP();

                segCP.Actualizar_Estado(seg.Id, seg.Estado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Seguimiento/Delete/5
        public ActionResult Delete(int id)
        {
            SeguimientoCEN segui = new SeguimientoCEN();
            segui.Eliminar(id);

            return View();
        }

        // POST: Seguimiento/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
