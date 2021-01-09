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
        public ActionResult Index(string email)
        {
            

            SessionInitialize();
            AdministradorCAD admiCAD = new AdministradorCAD(session);
            AdministradorCEN adminiCEN = new AdministradorCEN(admiCAD);
            

            IList<AdministradorEN> administradores = adminiCEN.Dame_Todos(0, -1);
            AdministradorEN admin = administradores[0];
            UsuarioEN usuen = new UsuarioEN();

            if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
            {
                UsuarioCAD usuarioCAD = new UsuarioCAD(session);
                
                   IList<UsuarioEN> usuarios = usuarioCAD.Dame_Todos(0,-1);
                foreach(UsuarioEN usu in usuarios)
                {
                    if (usu.Email.Equals(email))
                    {
                        usuen = usu;
                    }
                }

                
                TempData["emailUsu"] = email;

            }
            else {

              usuen = ((UsuarioEN)Session["Usuario"]);
            }
           

            MensajeCAD menCAD = new MensajeCAD(session);
            MensajeCEN menCEN = new MensajeCEN(menCAD);

            IList<MensajeEN> todos = menCEN.Dame_Todos(0, -1);

            IList<MensajeEN> mensajesUsu = new List<MensajeEN>();
            IList<MensajeEN> mensajesAdmin = new List<MensajeEN>();

            if (todos.Count>0)
            {
                //me quedo con los mensajes que ha enviado el usuario
                mensajesUsu = todos.Where(s => s.Enviador == usuen.Nombre).ToList();

                //me quedo con los mensajes que ha enviado el administrador
                //luego me quedo con los que ha enviado al usuario del chat
                mensajesAdmin = todos.Where(s => s.Enviador == admin.Nombre).ToList();
                mensajesAdmin = mensajesAdmin.Where(s => s.Usuario.Email == usuen.Email).ToList();
            }
            
            IList<MensajeEN> mensajes= new List<MensajeEN>();
            
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
                SessionInitialize();
                MensajeCP menCP = new MensajeCP();

                UsuarioEN usuen = ((UsuarioEN)Session["Usuario"]);

                AdministradorCAD admiCAD = new AdministradorCAD(session);
                AdministradorCEN adminiCEN = new AdministradorCEN(admiCAD);

                IList<AdministradorEN> administradores = adminiCEN.Dame_Todos(0, -1);
                AdministradorEN admin = administradores[0];

                //si el usuario de la sesion es el admin, hay que obtener los datos del usuario del chat para pasar el email
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {
                    menCP.Nuevo(admin.Email, (string)TempData["emailUsu"], mensa.Texto, DateTime.Now, usuen.Nombre);
                }
                else
                {
                    menCP.Nuevo(admin.Email, usuen.Email, mensa.Texto, DateTime.Now, usuen.Nombre);
                }
               

                TempData["mensajeModalSeguimiento"] = "Mensaje enviado con exito";

                SessionClose();
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {
                    return RedirectToAction("Index", new { email = (string)TempData["emailUsu"] });
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalSeguimiento"] = "Ha habido un error al enviar el mensaje";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
          
            return View();
        }

        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(MensajeViewModel men)
        {
            

            try
            {
                // TODO: Add delete logic here
                MensajeCEN mensajeCEN = new MensajeCEN();
                mensajeCEN.Eliminar(men.Id);

                TempData["mensajeModalEspecie"] = "Mensaje eliminado correctamente";
                if (((UsuarioEN)Session["Usuario"]).GetType() == typeof(AdministradorEN))
                {
                    return RedirectToAction("Index", new { email = (string)TempData["emailUsu"] });
                }
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalEspecie"] = "Ha habido un error al eliminar el mensaje";
                return RedirectToAction("Index");
            }
        }
    }
}