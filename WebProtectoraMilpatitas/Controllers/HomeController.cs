using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace WebProtectoraMilpatitas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            AnimalCEN animal = new AnimalCEN();
            IEnumerable<AnimalEN> listAni = animal.Dame_Todos(0, -1).ToList();

            ViewData["NumAni"] = listAni.Count();

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