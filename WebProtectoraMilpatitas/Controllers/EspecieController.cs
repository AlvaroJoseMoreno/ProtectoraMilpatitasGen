using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebProtectoraMilpatitas.Assemblers;
using WebProtectoraMilpatitas.Models;

namespace WebProtectoraMilpatitas.Controllers
{
    [Authorize]

    public class EspecieController : BasicController
    {
        // GET: Especie
        public ActionResult Index(int? page)
        {
            SessionInitialize();

            EspecieCAD especieCAD = new EspecieCAD(session);
            EspecieCEN especieCEN = new EspecieCEN(especieCAD);
            IList<EspecieEN> listaEspecie = especieCEN.Dame_Todas(0, -1);
            IEnumerable<EspecieViewModel> listaView = new EspecieAssembler().ConvertListENToModel(listaEspecie).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaView.ToPagedList(pageNumber, pageSize));
        }

        // GET: Especie/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            
            EspecieViewModel esp = null;
            EspecieEN espEN = new EspecieCAD(session).Dame_Por_Id(id);
            esp = new EspecieAssembler().ConvertENToModelUI(espEN);

            SessionClose();
            return View(esp);
        }

        // GET: Especie/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(EspecieViewModel esp)
        {
            try
            {
                // TODO: Add insert logic here

                EspecieCEN espCEN = new EspecieCEN();
                espCEN.Nuevo(esp.Nombre);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Edit/5
        public ActionResult Edit(int id)
        {
            EspecieViewModel esp = null;

            SessionInitialize();
            EspecieEN espEN = new EspecieCAD(session).Dame_Por_Id(id);
            esp = new EspecieAssembler().ConvertENToModelUI(espEN);
            SessionClose();

            return View(esp);
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(EspecieViewModel esp)
        {
            try
            {
                // TODO: Add update logic here

                EspecieCEN espcen = new EspecieCEN();
                espcen.Modificar(esp.Id, esp.Nombre);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Especie/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            EspecieCAD espCad = new EspecieCAD(session);
            EspecieCEN especieCEN = new EspecieCEN(espCad);
            ViewData["NombreEsp"] = especieCEN.Dame_Por_Id(id).Nombre;

            SessionClose();
            return View();
        }

        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(EspecieViewModel esp)
        {
            try
            {
                // TODO: Add delete logic here
                EspecieCEN especieCEN = new EspecieCEN();
                especieCEN.Eliminar(esp.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
