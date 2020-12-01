using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;

namespace ProtectoraMilPatitas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UsuarioCEN usucen = new UsuarioCEN();
            IEnumerable<UsuarioEN> listaUsuarios =  usucen.Dame_Todos(0, -1).ToList();
            return View(listaUsuarios);
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