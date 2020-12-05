using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using WebProtectoraMilpatitas.Assemblers;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Controllers
{
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
            return View();
        }

        // GET: SolicitudAdopcion/Create
        public ActionResult Create(int num, string nom)
        {
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

              //  soliCEN.Nuevo(sol.Nombre, sol.)
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
            return View();
        }

        // POST: SolicitudAdopcion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SolicitudAdopcion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
