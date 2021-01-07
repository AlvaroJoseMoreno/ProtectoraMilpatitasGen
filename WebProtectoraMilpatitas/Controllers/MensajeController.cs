using System;
using System.Collections.Generic;
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
    public class MensajeController:BasicController
    {
        public ActionResult Index()
        {
            

            SessionInitialize();

            MensajeCAD menCAD = new MensajeCAD(session);
            MensajeCEN menCEN = new MensajeCEN(menCAD);

            IList<MensajeEN> menEN = menCEN.Dame_Todos(0, -1);


            IEnumerable<MensajeViewModel> listaMensajes = new MensajeAssembler().ConvertListENToModel(menEN).ToList();

            SessionClose();

          

            return View(listaMensajes);
        }

        public ActionResult Create()
        {

            return View();

        }

        // POST: Seguimiento/Create
        [HttpPost]
        public ActionResult Create(MensajeViewModel mensa)
        {
          

            try
            {
                // TODO: Add insert logic here
                MensajeCEN menCEN = new MensajeCEN();

                UsuarioEN usuen = ((UsuarioEN)Session["Usuario"]);

                menCEN.Nuevo("protectoramilpatitasalicante@gmail.com",usuen.Email,mensa.Texto);
               

                TempData["mensajeModalSeguimiento"] = "Mensaje enviado con exiro";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalSeguimiento"] = "Ha habido un error al enviar el mensaje";
                return RedirectToAction("Index");
            }
        }
    }
}