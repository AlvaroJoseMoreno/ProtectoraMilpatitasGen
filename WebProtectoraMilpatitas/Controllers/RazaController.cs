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
    public class RazaController : BasicController
    {
        [Authorize]

        // GET: Raza
        public ActionResult Index(int? page)
        {
            SessionInitialize();

            RazaCAD razCAD = new RazaCAD(session);
            RazaCEN razCEN = new RazaCEN(razCAD);

            IList<RazaEN> razsEN = razCEN.Dame_Todas(0, -1);

            IEnumerable<RazaViewModel> listaRazas = new RazaAssembler().ConvertListENToModel(razsEN).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaRazas.ToPagedList(pageNumber, pageSize));
        }

        // GET: Raza/Details/5
        public ActionResult Details(int id)
        {
            RazaViewModel raz = null;

            SessionInitialize();

            RazaEN razEN = new RazaCAD(session).Dame_Por_Id(id);

            raz = new RazaAssembler().ConvertENToModelUI(razEN);

            SessionClose();

            return View(raz);
        }

        // GET: Raza/Create
        public ActionResult Create()
        {
            IList<EspecieEN> listaEspecies = new EspecieCEN().Dame_Todas(0, -1);
            IList<SelectListItem> especiesItems = new List<SelectListItem>();

            foreach (EspecieEN esp in listaEspecies)
            {
                especiesItems.Add(new SelectListItem { Text = esp.Nombre, Value = esp.Id.ToString() });
            }

            ViewData["idEspecie"] = especiesItems;

            return View();
        }

        // POST: Raza/Create
        [HttpPost]
        public ActionResult Create(RazaViewModel raz)
        {
            try
            {
                // TODO: Add insert logic here

                RazaCEN razCEN = new RazaCEN();
                razCEN.Nuevo(raz.Nombre, raz.idEspecie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ObtenerRazasPorEspecie(int p_especie, int? page)
        {
            SessionInitialize();

            RazaCAD razCad = new RazaCAD(session);
            EspecieCAD espeCad = new EspecieCAD(session);
            RazaCEN razCEN = new RazaCEN(razCad);
            IList<RazaEN> listRaz = razCEN.Dame_Raza_Por_Especie(p_especie);
            IEnumerable<RazaViewModel> listRaz2 = new RazaAssembler().ConvertListENToModel(listRaz).ToList();
            EspecieEN espEN = espeCad.Dame_Por_Id(p_especie);

            ViewData["idEspecie"] = p_especie;

            if (espEN != null)
            {
                ViewData["NombreEspecie"] = espEN.Nombre;
            }

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listRaz2.ToPagedList(pageNumber, pageSize));
        }

        // GET: Raza/Edit/5
        public ActionResult Edit(int id)
        {
            RazaViewModel raz = null;

            SessionInitialize();

            RazaEN razEN = new RazaCAD(session).Dame_Por_Id(id);

            raz = new RazaAssembler().ConvertENToModelUI(razEN);

            SessionClose();

            return View(raz);
        }

        // POST: Raza/Edit/5
        [HttpPost]
        public ActionResult Edit(RazaViewModel raz)
        {
            try
            {
                // TODO: Add update logic here

                RazaCEN razCEN = new RazaCEN();
                razCEN.Modificar(raz.Id, raz.Nombre);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Raza/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();
            RazaCAD razCad = new RazaCAD(session);
            RazaCEN razaCEN = new RazaCEN(razCad);
            ViewData["NombreRaz"] = razaCEN.Dame_Por_Id(id).Nombre;

            SessionClose();
            return View();
        }

        // POST: Raza/Delete/5
        [HttpPost]
        public ActionResult Delete(RazaViewModel raz)
        {
            try
            {
                // TODO: Add delete logic here

                RazaCEN razCEN = new RazaCEN();
                razCEN.Eliminar(raz.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
