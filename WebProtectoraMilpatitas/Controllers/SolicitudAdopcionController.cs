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
    public class SolicitudAdopcionController : BasicController
    {
        public ActionResult Index()
        {
            SessionInitialize();

            SolicitudAdopcionCAD solCAD = new SolicitudAdopcionCAD(session);
            SolicitudAdopcionCEN solCEN = new SolicitudAdopcionCEN(solCAD);

            IList<SolicitudAdopcionEN> solsEN = solCEN.Dame_Todas(0, -1);

            IEnumerable<SolicitudAdopcionViewModel> listaSolicitudes = new SolicitudAdopcionAssembler().ConvertListENToModel(solsEN).ToList();

            SessionClose();

            return View(listaSolicitudes);
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
            try
            {
                // TODO: Add insert logic here
                SolicitudAdopcionCEN soliCEN = new SolicitudAdopcionCEN();

                soliCEN.Nuevo(sol.idUsuario, sol.idAnimal);

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

        public ActionResult ObtenerSolicitudUsuario(string email)
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

            return View(listaSol);
        }

        // GET: SolicitudAdopcion/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
              SolicitudAdopcionCEN solCEN = new SolicitudAdopcionCEN();

                solCEN.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: SolicitudAdopcion/Delete/5
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
