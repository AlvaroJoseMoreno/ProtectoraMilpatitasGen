using System;
using System.Collections.Generic;
using System.IO;
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
    public class AnimalController : BasicController
    {
        [Authorize]
        //GET: Animal
        public ActionResult Index(int? page)
        {
            SessionInitialize();

            AnimalCAD animalCAD = new AnimalCAD(session);
            AnimalCEN animalCEN = new AnimalCEN(animalCAD);
            IList<AnimalEN> listaAnimal = animalCEN.Dame_Todos(0, -1);
            IEnumerable<AnimalViewModel> listaView = new AnimalAssembler().ConvertListENToModel(listaAnimal).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaView.ToPagedList(pageNumber,pageSize));
        }

        [Authorize]
        // GET: /AnimalViewModels/ObtenerAnimalesPorEspecie/5
        public ActionResult ObtenerAnimalesPorEspecie(int p_especie, int? page)
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

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listAni2.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult ObtenerAnimalesPorUsuario(string email, int? page)
        {
            SessionInitialize();

            AnimalCAD aniCad = new AnimalCAD(session);
            UsuarioCAD usuCad = new UsuarioCAD(session);

            AnimalCEN aniCEN = new AnimalCEN(aniCad);
            UsuarioCEN usuCEN = new UsuarioCEN(usuCad);

            UsuarioEN usuEN = usuCEN.Dame_Por_Email(email);

            IList<AnimalEN> listAni = usuEN.Mascotas;
            IEnumerable<AnimalViewModel> listAni2 = new AnimalAssembler().ConvertListENToModel(listAni).ToList();

            ViewData["NombreUsu"] = usuEN.Nombre;

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listAni2.ToPagedList(pageNumber, pageSize));
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

        [Authorize]
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

            IList<RazaEN> listaRazas = new RazaCEN().Dame_Todas(0, -1);
            IList<SelectListItem> razasItems = new List<SelectListItem>();

            foreach(RazaEN raz in listaRazas)
            {
                razasItems.Add(new SelectListItem { Text = raz.Nombre, Value = raz.Id.ToString() });
            }

            ViewData["idRaza"] = razasItems;

            return View();
        }

        [Authorize]
        // POST: Animal/Create
        [HttpPost]
        public ActionResult Create(AnimalViewModel ani, HttpPostedFileBase file)
        {
            string filename = "";
            string ruta = "";
            if (file != null && file.ContentLength > 0)
            {

                filename = Path.GetFileName(file.FileName);
                ruta = Path.Combine(Server.MapPath("~/Imagenes/animales/"), filename);
                file.SaveAs(ruta);
            }

            try
            {
                // TODO: Add insert logic here
                //   filename =" + filename;
                filename = "Imagenes/animales/" + filename;
                AnimalCP animalCP = new AnimalCP();
                animalCP.Nuevo(ani.Nombre, ani.Edad, ani.Sexo, ani.Centro, ani.DatosMedicos, ani.Caracter, ani.idEspecie, filename, ani.FechaLlegada, ani.idRaza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
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

        [Authorize]
        // POST: Animal/Edit/5
        [HttpPost]
        public ActionResult Edit(AnimalViewModel ani, HttpPostedFileBase file)
        {
            string filename = "";
            string ruta = "";
            if (file != null && file.ContentLength > 0)
            {

                filename = Path.GetFileName(file.FileName);
                ruta = Path.Combine(Server.MapPath("~/Imagenes/animales/"), filename);
                file.SaveAs(ruta);
            }
            try
            {
                // TODO: Add update logic here
                filename = "Imagenes/animales/" + filename;
                AnimalCEN anicen = new AnimalCEN();
                anicen.Modificar(ani.Id,ani.Nombre,ani.Edad,ani.Sexo,ani.Centro,ani.Caracter,filename);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult ActualizarEstado(int id)
        {
            AnimalViewModel ani = null;
            SessionInitialize();
            AnimalEN artEN = new AnimalCAD(session).Ver_Detalle_Animal(id);
            ani = new AnimalAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(ani);
        }

        [Authorize]
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

        [Authorize]
        public ActionResult ActualizarDatosMedicos(int id)
        {
            AnimalViewModel ani = null;
            SessionInitialize();
            AnimalEN artEN = new AnimalCAD(session).Ver_Detalle_Animal(id);
            ani = new AnimalAssembler().ConvertENToModelUI(artEN);
            SessionClose();
            return View(ani);
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        // GET: Animal/buscaranimales
        public ActionResult BuscarAnimales()
        {
            IList<EspecieEN> listaEspecies = new EspecieCEN().Dame_Todas(0, -1);
            IList<SelectListItem> especiesItems = new List<SelectListItem>();

            foreach (EspecieEN esp in listaEspecies)
            {
                especiesItems.Add(new SelectListItem { Text = esp.Nombre, Value = esp.Id.ToString() });
            }

            ViewData["idBusEspecie"] = especiesItems;

            IList<RazaEN> listaRazas = new RazaCEN().Dame_Todas(0, -1);
            IList<SelectListItem> razasItems = new List<SelectListItem>();

            foreach (RazaEN raz in listaRazas)
            {
                razasItems.Add(new SelectListItem { Text = raz.Nombre, Value = raz.Id.ToString() });
            }

            ViewData["idBusRaza"] = razasItems;

            return View();
        }

        // POST: Animal/Create
        [HttpPost]
        public ActionResult BuscarAnimales(AnimalViewModel ani)
        {
           try
            {
                // TODO: Add insert logic here
                //   filename =" + filename;
                SessionInitialize();

                AnimalCAD aniCad = new AnimalCAD(session);
                AnimalCEN animalCEN= new AnimalCEN(aniCad);
                
                IList<AnimalEN> animalesfiltrados = animalCEN.BuscarAnimales(ani.Nombre, ani.Edad, ani.Sexo, ani.Centro, ani.DatosMedicos, ani.Caracter, ani.FechaLlegada, ani.idEspecie);
           
               
                IEnumerable<AnimalViewModel> anifiltrados = new AnimalAssembler().ConvertListENToModel(animalesfiltrados).ToList();
                SessionClose();

                TempData["Animales"] = anifiltrados;

                return RedirectToAction("ResultadoBuscar");

            }
            catch
            {
                return View();
            }
        }

        //public ActionResult BusquedaRapida()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult BusquedaRapida(string nom)
        {
            try
            {
                // TODO: Add insert logic here
                //   filename =" + filename;
                SessionInitialize();

                AnimalCAD aniCad = new AnimalCAD(session);
                AnimalCEN animalCEN = new AnimalCEN(aniCad);

                IList<AnimalEN> animalesfiltrados = animalCEN.BusquedaRapida(nom);

                IEnumerable<AnimalViewModel> anifiltrados = new AnimalAssembler().ConvertListENToModel(animalesfiltrados).ToList();
                
                SessionClose();

                TempData["Animales"] = anifiltrados;

                return RedirectToAction("ResultadoBuscar");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult ResultadoBuscar()
        {

            return View(TempData["Animales"]);
        }
    }
}
