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
            UsuarioCEN usuario = new UsuarioCEN();
            IEnumerable<UsuarioEN> listUsuas = usuario.Dame_Todos(0, -1).ToList();

            return View(listAni);
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