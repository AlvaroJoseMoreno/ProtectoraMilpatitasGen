using System;
using System.Collections.Generic;
using System.IO;
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
            EspecieCAD especieCAD = new EspecieCAD(session);
            IList<AnimalEN> listaAnimal = animalCEN.Dame_Todos(0, -1);
            IEnumerable<AnimalViewModel> listaView = new AnimalAssembler().ConvertListENToModel(listaAnimal).ToList();
            
        //    EspecieEN espEN = especieCAD.Dame_Por_Id(anim);
            foreach (AnimalEN ani in listaAnimal)
            {
                ViewData["NombreEsp"] = ani.Especie.Nombre;
            }

            SessionClose();

            return View(listaView);
        }

        // GET: /AnimalViewModels/ObtenerAnimalesPorEspecie/5
        public ActionResult ObtenerAnimalesPorEspecie(int p_especie)
        {
            SessionInitialize();

            AnimalCAD aniCad = new AnimalCAD(session);
            EspecieCAD espeCad = new EspecieCAD(session);
            AnimalCEN aniCEN = new AnimalCEN(aniCad);
            IList<AnimalEN> listAni = aniCEN.Dame_Animales_Por_Especie(p_especie);
            IEnumerable<AnimalViewModel> listAni2 = new AnimalAssembler().ConvertListENToModel(listAni).ToList();
            EspecieEN espEN = espeCad.Dame_Por_Id(p_especie);

            ViewData["idEspecie"] = p_especie;

            if(espEN != null)
            {
                ViewData["NombreEspecie"] = espEN.Nombre;
            }

            SessionClose();
            return View(listAni2);
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();
            EspecieCAD espeCad = new EspecieCAD(session);
            AnimalViewModel ani = null;
            AnimalEN artEN = new AnimalCAD(session).Ver_Detalle_Animal(id);
            ani = new AnimalAssembler().ConvertENToModelUI(artEN);

            EspecieEN espEN = espeCad.Dame_Por_Id(ani.idEspecie);

            if (espEN != null)
            {
                ViewData["NombreEsp"] = espEN.Nombre;
            }


            SessionClose();
            return View(ani);
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            IList<EspecieEN> listaAnimales = new EspecieCEN().Dame_Todas(0, -1);
            IList<SelectListItem> especiesItems = new List<SelectListItem>();

            foreach (EspecieEN esp in listaAnimales)
            {
                especiesItems.Add(new SelectListItem { Text = esp.Nombre, Value = esp.Id.ToString() });
            }

            ViewData["idEspecie"] = especiesItems;

            return View();
        }

        // POST: Animal/Create
        [HttpPost]
        public ActionResult Create(AnimalViewModel ani, HttpPostedFileBase file)
        {
            string filename = "";
            string ruta = "";
            if (file != null && file.ContentLength > 0)
            {

                filename = Path.GetFileName(file.FileName);
                ruta = Path.Combine(Server.MapPath("~/Imagenes"), filename);
                file.SaveAs(ruta);
            }

            try
            {
                // TODO: Add insert logic here
                //   filename =" + filename;
                filename = "Imagenes/" + filename;
                AnimalCP animalCP = new AnimalCP();
                animalCP.Nuevo(ani.Nombre, ani.Edad, ani.Sexo, ani.Centro, ani.DatosMedicos, ani.Caracter, ani.idEspecie, filename);

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
            AnimalEN artEN = new AnimalCAD(session).Ver_Detalle_Animal(id);
            ani = new AnimalAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(ani);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        public ActionResult Edit(AnimalViewModel ani, HttpPostedFileBase file)
        {
            string filename = "";
            string ruta = "";
            if (file != null && file.ContentLength > 0)
            {

                filename = Path.GetFileName(file.FileName);
                ruta = Path.Combine(Server.MapPath("~/Imagenes"), filename);
                file.SaveAs(ruta);
            }
            try
            {
                // TODO: Add update logic here
                filename = "Imagenes/" + filename;
                AnimalCEN anicen = new AnimalCEN();
                anicen.Modificar(ani.Id,ani.Nombre,ani.Edad,ani.Sexo,ani.Centro,ani.Caracter,filename);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ActualizarEstado(int id)
        {
            AnimalViewModel ani = null;
            SessionInitialize();
            AnimalEN artEN = new AnimalCAD(session).Ver_Detalle_Animal(id);
            ani = new AnimalAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(ani);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        public ActionResult ActualizarEstado(AnimalViewModel ani)
        {
            try
            {
                // TODO: Add update logic here
                AnimalCEN anicen = new AnimalCEN();
                anicen.Actualizar_Estado(ani.Id, ani.EstadoAdopcion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ActualizarDatosMedicos(int id)
        {
            AnimalViewModel ani = null;
            SessionInitialize();
            AnimalEN artEN = new AnimalCAD(session).Ver_Detalle_Animal(id);
            ani = new AnimalAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(ani);
        }

        // POST: Animal/Edit/5
        [HttpPost]
        public ActionResult ActualizarDatosMedicos(AnimalViewModel ani)
        {
            try
            {
                // TODO: Add update logic here
                AnimalCEN anicen = new AnimalCEN();
                anicen.Actualizar_DatosMedicos(ani.Id, ani.DatosMedicos);
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
            SessionInitialize();
            AnimalCAD aniCad = new AnimalCAD(session);
            AnimalCEN animalCEN = new AnimalCEN(aniCad);
            ViewData["NombreAnim"] = animalCEN.Ver_Detalle_Animal(id).Nombre;

            SessionClose();
            return View();
        }

        // POST: Animal/Delete/5
        [HttpPost]
        public ActionResult Delete(AnimalViewModel ani)
        {
            try
            {
                // TODO: Add delete logic here
               
                AnimalCEN animalCEN = new AnimalCEN();
                animalCEN.Eliminar(ani.Id);
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
