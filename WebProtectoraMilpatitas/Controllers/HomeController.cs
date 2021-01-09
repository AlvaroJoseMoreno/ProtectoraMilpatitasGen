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
    public class HomeController : BasicController
    {
        [Authorize]
        public ActionResult Indexad()
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

            AnimalCEN animal = new AnimalCEN();
            IEnumerable<AnimalEN> listAni = animal.Dame_Todos(0, -1).ToList();

            ViewData["NumAni"] = listAni.Count();

            TestAnimalIdealCEN test = new TestAnimalIdealCEN();
            IEnumerable<TestAnimalIdealEN> listTest = test.Dame_Todos(0, -1).ToList();

            ViewData["NumTest"] = listTest.Count();

            UsuarioCEN usuario = new UsuarioCEN();
            IEnumerable<UsuarioEN> listUsuas = usuario.Dame_Todos(0, -1).ToList();

            ViewData["NumUsu"] = listUsuas.Count();

            SolicitudAdopcionCEN solicitud = new SolicitudAdopcionCEN();
            IEnumerable<SolicitudAdopcionEN> listSol = solicitud.Dame_Todas(0, -1).ToList();

            ViewData["NumSol"] = listSol.Count();

            ContratoAdopcionCEN contrato = new ContratoAdopcionCEN();
            IEnumerable<ContratoAdopcionEN> listCon = contrato.Dame_Todos(0, -1).ToList();

            ViewData["NumCon"] = listCon.Count();

            SeguimientoCEN seguimiento = new SeguimientoCEN();
            IEnumerable<SeguimientoEN> listSeg = seguimiento.Dame_Todos(0, -1).ToList();

            ViewData["NumSeg"] = listSeg.Count();

            return View();
        }

        public ActionResult Index(int? page, string sortOrder, string nameSearch, string edadSearch, string sexoSearch, string centroSearch, string caracterSearch, string estSearch, string espSearch, string razSearch)
        {
            SessionInitialize();

            AnimalCAD animalCAD = new AnimalCAD(session);
            AnimalCEN animalCEN = new AnimalCEN(animalCAD);
            IList<AnimalEN> listaAnimal = animalCEN.Dame_Todos(0, -1);

            IList<AnimalEN> ordenada = listaAnimal.OrderByDescending(o => o.FechaLlegada).ToList();

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
                ordenada = ordenada.Where(s => s.Nombre.Contains(nameSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(edadSearch))
            {
                ordenada = ordenada.Where(s => s.Edad.ToString() == edadSearch).ToList();
            }

            if (!String.IsNullOrEmpty(sexoSearch))
            {
                ordenada = ordenada.Where(s => s.Sexo.ToString() == sexoSearch).ToList();
            }

            if (!String.IsNullOrEmpty(centroSearch))
            {
                ordenada = ordenada.Where(s => s.Centro.Contains(centroSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(caracterSearch))
            {
                ordenada = ordenada.Where(s => s.Caracter.Contains(caracterSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(estSearch))
            {
                ordenada = ordenada.Where(s => s.DatosMedicos.ToString().Contains(estSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(espSearch))
            {
                ordenada = ordenada.Where(s => s.Especie.Nombre.Contains(espSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(razSearch))
            {
                ordenada = ordenada.Where(s => s.Raza.Nombre.Contains(razSearch)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    ordenada = ordenada.OrderByDescending(s => s.Nombre).ToList();
                    break;
                case "edad_desc":
                    ordenada = ordenada.OrderByDescending(s => s.Edad).ToList();
                    break;
                case "sexo_desc":
                    ordenada = ordenada.OrderByDescending(s => s.Sexo).ToList();
                    break;
                case "centro_desc":
                    ordenada = ordenada.OrderByDescending(s => s.Centro).ToList();
                    break;
                case "carac_desc":
                    ordenada = ordenada.OrderByDescending(s => s.Caracter).ToList();
                    break;
                case "est_desc":
                    ordenada = ordenada.OrderByDescending(s => s.EstadoAdopcion).ToList();
                    break;
                case "esp_desc":
                    ordenada = ordenada.OrderByDescending(s => s.Especie.Nombre).ToList();
                    break;
                case "raz_desc":
                    ordenada = ordenada.OrderByDescending(s => s.Raza.Nombre).ToList();
                    break;
                default:
                    ordenada = ordenada.OrderBy(s => s.Nombre).ToList();
                    break;
            }

            IEnumerable<AnimalViewModel> listaView = new AnimalAssembler().ConvertListENToModel(ordenada).ToList();

            SessionClose();

          
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaView.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}