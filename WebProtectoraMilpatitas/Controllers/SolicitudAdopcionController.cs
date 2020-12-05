using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProtectoraMilpatitas.Controllers
{
    public class SolicitudAdopcionController : BasicController
    {
        // GET: SolicitudAdopcion
        public ActionResult Index()
        {
            return View();
        }

        // GET: SolicitudAdopcion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SolicitudAdopcion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SolicitudAdopcion/Create
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
