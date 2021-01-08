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
            AdministradorCAD admiCAD = new AdministradorCAD(session);
            AdministradorCEN adminiCEN = new AdministradorCEN(admiCAD);
            



            IList<AdministradorEN> administradores = adminiCEN.Dame_Todos(0, -1);
            AdministradorEN admin = administradores[0];
            UsuarioEN usuen = ((UsuarioEN)Session["Usuario"]);

            IList<MensajeEN> mensajesAdmin = admin.MensajeAdmin;
            IList<MensajeEN> mensajesUsu = usuen.MensajeChat;
            IList<MensajeEN> mensajes= usuen.MensajeChat;

            if (mensajesAdmin.Count > 0 )
            {
                foreach (MensajeEN men in mensajesAdmin)
                {
                    mensajesUsu.Add(men);
                }
                 mensajes = mensajesUsu;
            }
            else if (mensajesUsu.Count > 0)
            {
                foreach (MensajeEN men in mensajesUsu)
                {
                    mensajesAdmin.Add(men);
                }
                mensajes = mensajesAdmin;
            }

            IEnumerable<MensajeEN> mensajesOrden = mensajes.OrderBy(f => f.Fecha);
            IList<MensajeEN> sortedList = mensajesOrden.ToList();



            IEnumerable<MensajeViewModel> listaMensajes = new MensajeAssembler().ConvertListENToModel(sortedList).ToList();

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
                MensajeCP menCP = new MensajeCP();

                UsuarioEN usuen = ((UsuarioEN)Session["Usuario"]);

                menCP.Nuevo("protectoramilpatitasalicante@gmail.com",usuen.Email,mensa.Texto, DateTime.Now);
               

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