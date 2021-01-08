using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
    [Authorize]
    public class UsuarioController : BasicController
    {
        // GET: Usuario
        public ActionResult Index(int? page, string sortOrder, string nameSearch)
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

            UsuarioCAD usuarioCAD = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuarioCAD);

            IList<UsuarioEN> listaUsuarios = usuarioCEN.Dame_Todos(0, -1);

            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (!String.IsNullOrEmpty(nameSearch))
            {
                listaUsuarios = listaUsuarios.Where(s => s.Nombre.Contains(nameSearch)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    listaUsuarios = listaUsuarios.OrderByDescending(s => s.Nombre).ToList();
                    break;
                default:
                    listaUsuarios = listaUsuarios.OrderBy(s => s.Nombre).ToList();
                    break;
            }

            IEnumerable<UsuarioViewModel> listaView = new UsuarioAssembler().ConvertListENToModel(listaUsuarios).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaView.ToPagedList(pageNumber, pageSize));
        }

        // GET: Usuario/Details/5
        public ActionResult Details(string email)
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

            UsuarioViewModel usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).Dame_Por_Email(email);
            usu = new UsuarioAssembler().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        public ActionResult Perfil(string email)
        {
            UsuarioViewModel usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).Dame_Por_Email(email);
            usu = new UsuarioAssembler().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuario, HttpPostedFileBase file)
        {
            string filename = "";
            string ruta = "";
            if (file != null && file.ContentLength > 0)
            {

                filename = Path.GetFileName(file.FileName);
                ruta = Path.Combine(Server.MapPath("~/Imagenes/usuarios"), filename);
                file.SaveAs(ruta);
            }

            try
            {
                // TODO: Add insert logic here
                filename = "Imagenes/usuarios" + filename;
                UsuarioCEN usuCEN = new UsuarioCEN();

                string mail = usuCEN.Registrarse(usuario.Nombre, usuario.Email, usuario.Password, filename);

                AdministradorEN admin = new AdministradorCEN().Dame_Todos(0, -1)[0];
                UsuarioEN usu = usuCEN.Dame_Por_Email(mail);
                MensajeEN menP = new MensajeCP().Nuevo(admin.Email, usu.Email, "Hola  " + usu.Nombre, DateTime.Now);

                TempData["mensajeModal"] = "¡Enhorabuena! Has creado un usuario";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(String email)
        {
            //esto no funciona bien
            UsuarioViewModel usu = null;
            SessionInitialize();
            UsuarioEN usuEN = new UsuarioCAD(session).Dame_Por_Email(email);
            usu = new UsuarioAssembler().ConvertENToModelUI(usuEN);
            SessionClose();
            return View(usu);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioViewModel usu, HttpPostedFileBase file)
        {
            string filename = "";
            string ruta = "";
            if (file != null && file.ContentLength > 0)
            {

                filename = Path.GetFileName(file.FileName);
                ruta = Path.Combine(Server.MapPath("~/Imagenes/usuarios/"), filename);
                file.SaveAs(ruta);
            }
            try
            {
                filename = "Imagenes/usuarios/" + filename;
                // TODO: Add update logic here
                UsuarioCEN usuarioCEN = new UsuarioCEN();
                usuarioCEN.Modificar(usu.Email, usu.Nombre, usu.Password, filename);
                TempData["mensajeModal"] = "¡Enhorabuena! Has editado la información del usuario con exito";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(string email)
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
            UsuarioCAD usuCad = new UsuarioCAD(session);
            UsuarioCEN usuarioCEN = new UsuarioCEN(usuCad);
            ViewData["NombreUsu"] = usuarioCEN.Dame_Por_Email(email).Nombre;

            SessionClose();
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(UsuarioViewModel usuario)
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
                UsuarioCEN usucen = new UsuarioCEN();
                usucen.Eliminar(usuario.Email);
                TempData["mensajeModal"] = "Has eliminado la información del usuario con exito";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
