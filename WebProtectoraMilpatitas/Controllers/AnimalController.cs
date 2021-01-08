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
        public ActionResult Index(int? page, string sortOrder, string nameSearch, string edadSearch, string sexoSearch, string centroSearch, string caracterSearch, string estSearch, string espSearch, string razSearch)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            SessionInitialize();

            AnimalCAD animalCAD = new AnimalCAD(session);
            AnimalCEN animalCEN = new AnimalCEN(animalCAD);
            IList<AnimalEN> listaAnimal = animalCEN.Dame_Todos(0, -1);

            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EdadSort = String.IsNullOrEmpty(sortOrder) ? "edad_desc" : "";
            ViewBag.SexoSort = String.IsNullOrEmpty(sortOrder) ? "sexo_desc" : "";
            ViewBag.CentroSort = String.IsNullOrEmpty(sortOrder) ? "centro_desc" : "";
            ViewBag.CaracterSort = String.IsNullOrEmpty(sortOrder) ? "carac_desc" : "";
            ViewBag.EstadoSort = String.IsNullOrEmpty(sortOrder) ? "est_desc" : "";
            ViewBag.EspecieSort = String.IsNullOrEmpty(sortOrder) ? "esp_desc" : "";
            ViewBag.RazaSort = String.IsNullOrEmpty(sortOrder) ? "raz_desc" : "";

            if (!String.IsNullOrEmpty(nameSearch))
            {
                listaAnimal = listaAnimal.Where(s => s.Nombre.Contains(nameSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(edadSearch))
            {
                listaAnimal = listaAnimal.Where(s => s.Edad.ToString() == edadSearch).ToList();
            }

            if (!String.IsNullOrEmpty(sexoSearch))
            {
                listaAnimal = listaAnimal.Where(s => s.Sexo.ToString() == sexoSearch).ToList();
            }

            if (!String.IsNullOrEmpty(centroSearch))
            {
                listaAnimal = listaAnimal.Where(s => s.Centro.Contains(centroSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(caracterSearch))
            {
                listaAnimal = listaAnimal.Where(s => s.Caracter.Contains(caracterSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(estSearch))
            {
                listaAnimal = listaAnimal.Where(s => s.DatosMedicos.ToString().Contains(estSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(espSearch))
            {
                listaAnimal = listaAnimal.Where(s => s.Especie.Nombre.Contains(espSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(razSearch))
            {
                listaAnimal = listaAnimal.Where(s => s.Raza.Nombre.Contains(razSearch)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    listaAnimal = listaAnimal.OrderByDescending(s => s.Nombre).ToList();
                    break;
                case "edad_desc":
                    listaAnimal = listaAnimal.OrderByDescending(s => s.Edad).ToList();
                    break;
                case "sexo_desc":
                    listaAnimal = listaAnimal.OrderByDescending(s => s.Sexo).ToList();
                    break;
                case "centro_desc":
                    listaAnimal = listaAnimal.OrderByDescending(s => s.Centro).ToList();
                    break;
                case "carac_desc":
                    listaAnimal = listaAnimal.OrderByDescending(s => s.Caracter).ToList();
                    break;
                case "est_desc":
                    listaAnimal = listaAnimal.OrderByDescending(s => s.EstadoAdopcion).ToList();
                    break;
                case "esp_desc":
                    listaAnimal = listaAnimal.OrderByDescending(s => s.Especie.Nombre).ToList();
                    break;
                case "raz_desc":
                    listaAnimal = listaAnimal.OrderByDescending(s => s.Raza.Nombre).ToList();
                    break;
                default:
                    listaAnimal = listaAnimal.OrderBy(s => s.Nombre).ToList();
                    break;
            }

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
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

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

            IList<AnimalEN> listAni = aniCEN.Obtener_Animal_Usuario(usuEN.Email);
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

           if (Session["Usuario"] != null) {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
           }

            IList<EspecieEN> listaEspecies = new EspecieCEN().Dame_Todas(0, -1);
            IList<SelectListItem> especiesItems = new List<SelectListItem>();

            foreach (EspecieEN esp in listaEspecies)
            {
                especiesItems.Add(new SelectListItem { Text=esp.Nombre, Value=esp.Id.ToString()});
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
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

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

                TempData["mensajeModalAnimal"] = "Se ha creado correctamente el animal";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalAnimal"] = "Ha habido un error al crear el animal";

                return RedirectToAction("Index");
            }
        }

        [Authorize]
        // GET: Animal/Edit/5
        public ActionResult Edit(int id)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

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
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

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

                TempData["mensajeModalAnimal"] = "Se ha editado correctamente el animal";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalAnimal"] = "Ha habido un error al editar el animal";

                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult ActualizarEstado(int id)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

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
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            try
            {

                // TODO: Add update logic here
                AnimalCEN anicen = new AnimalCEN();
                anicen.Actualizar_Estado(ani.Id, ani.EstadoAdopcion);

                TempData["mensajeModalAnimal"] = "Se ha actualizado el estado de adopción del animal correctamente";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalAnimal"] = "Ha habido un error al actualizar el estado de adopción del animal";

                return RedirectToAction("Index");
            }
        }

        [Authorize]
        public ActionResult ActualizarDatosMedicos(int id)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

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
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            try
            {
                // TODO: Add update logic here
                AnimalCEN anicen = new AnimalCEN();
                anicen.Actualizar_DatosMedicos(ani.Id, ani.DatosMedicos);

                TempData["mensajeModalAnimal"] = "Se ha actualizado el estado de salud del animal correctamente";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalAnimal"] = "Ha habido un error al actualizar el estado de salud del animal";

                return RedirectToAction("Index");
            }
        }

        [Authorize]
        // GET: Animal/Delete/5
        public ActionResult Delete(int id)
        {
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

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
            if (Session["Usuario"] != null)
            {
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            try
            {
                // TODO: Add delete logic here
               
                AnimalCEN animalCEN = new AnimalCEN();
                animalCEN.Eliminar(ani.Id);

                TempData["mensajeModalAnimal"] = "Se ha eliminado correctamente el animal";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalAnimal"] = "Ha habido un error al eliminar el animal";

                return RedirectToAction("Index");
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
        public ActionResult BuscarAnimales(BuscarAnimalViewModel ani)
        {
           try
            {
                // TODO: Add insert logic here
                //   filename =" + filename;
                SessionInitialize();

                AnimalCAD aniCad = new AnimalCAD(session);
                AnimalCEN animalCEN= new AnimalCEN(aniCad);

                TempData["fecha"] = ani.FechaLlegada;

                IList<AnimalEN> animalesfiltrados = animalCEN.BuscarAnimales(ani.Nombre, ani.Edad, ani.Sexo, ani.Centro, ani.DatosMedicos, ani.Caracter, ani.idBusEspecie, ani.idBusRaza/*, ani.FechaLlegada*/);
           
               
                IEnumerable<AnimalViewModel> anifiltrados = new AnimalAssembler().ConvertListENToModel(animalesfiltrados).ToList();
                SessionClose();

                Session["Animales"] = anifiltrados;

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

                Session["Animales"] = anifiltrados;

                return RedirectToAction("ResultadoBuscar");

            }
            catch
            {
                return View();
            }
        }

        public ActionResult ResultadoBuscar(int? page)
        {
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(((IEnumerable<AnimalViewModel>)Session["Animales"]).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ObtenerBabies(int? page)
        {
            SessionInitialize();

            AnimalCAD aniCad = new AnimalCAD(session);

            AnimalCEN aniCEN = new AnimalCEN(aniCad);

            IList<AnimalEN> listBabies = aniCEN.ObtenerBabies();

            IEnumerable<AnimalViewModel> babiesView = new AnimalAssembler().ConvertListENToModel(listBabies).ToList();
            
            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(babiesView.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ObtenerRecienLlegados(int? page)
        {
            SessionInitialize();

            AnimalCAD aniCad = new AnimalCAD(session);

            AnimalCEN aniCEN = new AnimalCEN(aniCad);

            IList<AnimalEN> listRecientes = aniCEN.ObtenerRecienLlegados();

            IEnumerable<AnimalViewModel> recientesView = new AnimalAssembler().ConvertListENToModel(listRecientes).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(recientesView.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ObtenerCasosEspeciales(int? page)
        {
            SessionInitialize();

            AnimalCAD aniCad = new AnimalCAD(session);

            AnimalCEN aniCEN = new AnimalCEN(aniCad);

            IList<AnimalEN> listEspeciales = aniCEN.ObtenerCasosEspeciales(ProtectoraMilpatitasGenNHibernate.Enumerated.ProtectoraMilpatitas.EstadoSaludEnum.enfermo);

            IEnumerable<AnimalViewModel> especialesView = new AnimalAssembler().ConvertListENToModel(listEspeciales).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(especialesView.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ObtenerUrgentes(int? page)
        {
            SessionInitialize();

            AnimalCAD aniCad = new AnimalCAD(session);

            AnimalCEN aniCEN = new AnimalCEN(aniCad);

            IList<AnimalEN> listUrgentes = aniCEN.ObtenerUrgentes();

            IEnumerable<AnimalViewModel> urgentesView = new AnimalAssembler().ConvertListENToModel(listUrgentes).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(urgentesView.ToPagedList(pageNumber, pageSize));
        }
    }
}
