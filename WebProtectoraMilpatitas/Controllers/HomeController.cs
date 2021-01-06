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

        public ActionResult Index(int? page)
        {
            SessionInitialize();

            AnimalCAD animalCAD = new AnimalCAD(session);
            AnimalCEN animalCEN = new AnimalCEN(animalCAD);
            IList<AnimalEN> listaAnimal = animalCEN.Dame_Todos(0, -1);

            IList<AnimalEN> ordenada = listaAnimal.OrderByDescending(o => o.FechaLlegada).ToList();

            IEnumerable<AnimalViewModel> listaView = new AnimalAssembler().ConvertListENToModel(ordenada).ToList();

            SessionClose();

          
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaView.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            //if (Session["RUTA"] == null)
            //{
            //    List<string> ruta = new List<string>();
            //    ruta.Add("Home/Index");
            //    Session["RUTA"] = ruta;
            //}
            //else
            //{
            //    List<string> ruta = ((List<string>)Session["RUTA"]);
            //    if (ruta.Count() > 0)
            //    {
            //        //ruta.RemoveAt(ruta.Count() - 1);
            //        ruta.Add("Home/About");
            //    }
            //}
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}