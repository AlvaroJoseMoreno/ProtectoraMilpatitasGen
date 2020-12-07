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
            return View();
        }

        // GET: Seguimiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seguimiento/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Seguimiento/Edit/5
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

        // GET: Seguimiento/Delete/5
        public ActionResult Delete(int id)
        {
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
