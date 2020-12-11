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
    public class AnimalController : BasicController
    {
        //GET: Animal
        public ActionResult Index()
        {
            SessionInitialize();

            AnimalCAD animalCAD = new AnimalCAD(session);
            AnimalCEN animalCEN = new AnimalCEN(animalCAD);

            IList<AnimalEN> listaAnimal = animalCEN.Dame_Todos(0, -1);
            IEnumerable<AnimalViewModel> listaView = new AnimalAssembler().ConvertListENToModel(listaAnimal).ToList();

            SessionClose();

            return View(listaView);
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Animal/Create
        [HttpPost]
        public ActionResult Create(AnimalViewModel ani)
        {
            try
            {
                // TODO: Add insert logic here

                AnimalCP animalCP = new AnimalCP();
                animalCP.Nuevo(ani.Nombre, ani.Edad, ani.Sexo, ani.Centro, ani.DatosMedicos, ani.Caracter, 3);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int id)
        {
            AnimalViewModel ani = null;
            SessionInitialize();
            AnimalEN artEN = new AnimalCAD(session).ReadOIDDefault(id);
            ani = new AnimalAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(ani);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        public ActionResult Edit(AnimalViewModel ani)
        {
            try
            {
                // TODO: Add update logic here
                AnimalCEN anicen = new AnimalCEN();
                anicen.Modificar(ani.Id,ani.Nombre,ani.Edad,ani.Sexo,ani.Centro,ani.Caracter);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int id)
        {
            AnimalCEN animalCEN = new AnimalCEN();
            animalCEN.Eliminar(id);
            return View();
        }

        // POST: Animal/Delete/5
        [HttpPost]
        public ActionResult Delete(AnimalViewModel ani)
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
