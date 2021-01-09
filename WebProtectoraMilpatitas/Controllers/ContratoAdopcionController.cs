﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public class ContratoAdopcionController : BasicController
    {
        // GET: ContratoAdopcion
        public ActionResult Index(int? page, string sortOrder, string nameSearch, string usuSearch, string aniSearch)
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

            ContratoAdopcionCAD conCAD = new ContratoAdopcionCAD(session);
            ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN(conCAD);

            IList<ContratoAdopcionEN> contsEN = conCEN.Dame_Todos(0, -1);

            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.UsuSort = String.IsNullOrEmpty(sortOrder) ? "usu_desc" : "";
            ViewBag.AniSort = String.IsNullOrEmpty(sortOrder) ? "ani_desc" : "";

            if (!String.IsNullOrEmpty(nameSearch))
            {
                contsEN = contsEN.Where(s => s.Nombre.Contains(nameSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(usuSearch))
            {
                contsEN = contsEN.Where(s => s.Usuario.Nombre.Contains(usuSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(aniSearch))
            {
                contsEN = contsEN.Where(s => s.Animal.Nombre.Contains(aniSearch)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    contsEN = contsEN.OrderByDescending(s => s.Nombre).ToList();
                    break;
                case "usu_desc":
                    contsEN = contsEN.OrderByDescending(s => s.Usuario.Nombre).ToList();
                    break;
                case "ani_desc":
                    contsEN = contsEN.OrderByDescending(s => s.Animal.Nombre).ToList();
                    break;
                default:
                    contsEN = contsEN.OrderBy(s => s.Nombre).ToList();
                    break;
            }

            IEnumerable<ContratoAdopcionViewModel> listaContratos = new ContratoAdopcionAssembler().ConvertListENToModel(contsEN).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaContratos.ToPagedList(pageNumber, pageSize));
        }

        // GET: ContratoAdopcion/Details/5
        public ActionResult Details(int id)
        {
            ContratoAdopcionViewModel con = null;

            SessionInitialize();

            ContratoAdopcionEN conEN = new ContratoAdopcionCAD(session).Ver_Contrato(id);

            con = new ContratoAdopcionAssembler().ConvertENToModelUI(conEN);

            SessionClose();

            return View(con);
        }

        // GET: ContratoAdopcion/Create
        public ActionResult Create()
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

            IList<UsuarioEN> listaUsuarios = new UsuarioCEN().Dame_Todos(0, -1);
            IList<SelectListItem> usuariosItems = new List<SelectListItem>();

            foreach (UsuarioEN usu in listaUsuarios)
            {
                usuariosItems.Add(new SelectListItem { Text = usu.Nombre, Value = usu.Email });
            }

            ViewData["idUsuario"] = usuariosItems;

            IList<SolicitudAdopcionEN> listaSolicitudes = new SolicitudAdopcionCEN().Dame_Todas(0, -1);
            IList<SelectListItem> solicitudesItems = new List<SelectListItem>();

            foreach (SolicitudAdopcionEN sol in listaSolicitudes)
            {
                solicitudesItems.Add(new SelectListItem { Text = sol.Nombre, Value = sol.Id.ToString() });
            }

            ViewData["idSolicitud"] = solicitudesItems;

            IList<AnimalEN> listaAnimales = new AnimalCEN().Dame_Todos(0, -1);
            IList<SelectListItem> animalesItems = new List<SelectListItem>();

            foreach (AnimalEN ani in listaAnimales)
            {
                animalesItems.Add(new SelectListItem { Text = ani.Nombre, Value = ani.Id.ToString() });
            }

            ViewData["idAnimal"] = animalesItems;

            return View();
        }

        // POST: ContratoAdopcion/Create
        [HttpPost]
        public ActionResult Create(ContratoAdopcionViewModel con)
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
                // TODO: Add insert logic here
                ContratoAdopcionCEN contCEN = new ContratoAdopcionCEN();

                
                contCEN.Nuevo(con.idUsuario, con.idSolicitud, con.idAnimal);
                TempData["mensajeModal"] = "Has creado un nuevo Contrato";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public FileResult Imprimir()
        {
            Document doc = new Document(PageSize.LETTER);
            string ruta = Path.Combine(Server.MapPath("~/Contratos"), "contrato.pdf");
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            PdfWriter writer = PdfWriter.GetInstance(doc, file);

            doc.AddAuthor("ProtectoraMilpatitas");
            doc.AddTitle("Contrato Adopcion");
            doc.Open();

            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            doc.Add(new Phrase("CONTRATO DE ADOPCIÓN"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Phrase("COMPARECIENDO"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Phrase("De una parte, D./Dña. .............................., en su propio nombre y Derecho, con DNI ..............., con domicilio en ..............................................., con teléfono .............................. y e-mail .............................................., en adelante el Adoptante."));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Phrase("Y, de una parte, D./Dña. .............................., en nombre y representación de la Protectora Milpatitas, con DNI ..............., con domicilio en ..............................................., con teléfono .............................. y e-mail .............................................., en adelante la Protectora."));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Phrase("Ambas partes acuerdan celebrar el presente CONTRATO, de acuerdo con las siguientes estipulaciones:"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Phrase("ESTIPULACIONES"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Phrase("1ª El Adoptante se compromete a adoptar al animal de la Protectora con los datos que se reseñan a continuación: "));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            PdfPTable tblPrueba = new PdfPTable(5);
            tblPrueba.WidthPercentage = 100;

            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clEdad = new PdfPCell(new Phrase("Edad", _standardFont));
            clEdad.BorderWidth = 0;
            clEdad.BorderWidthBottom = 0.75f;

            PdfPCell clSexo = new PdfPCell(new Phrase("Sexo", _standardFont));
            clSexo.BorderWidth = 0;
            clSexo.BorderWidthBottom = 0.75f;

            PdfPCell clEspecie= new PdfPCell(new Phrase("Especie", _standardFont));
            clEspecie.BorderWidth = 0;
            clEspecie.BorderWidthBottom = 0.75f;

            PdfPCell clRaza = new PdfPCell(new Phrase("Raza", _standardFont));
            clRaza.BorderWidth = 0;
            clRaza.BorderWidthBottom = 0.75f;

            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clEdad);
            tblPrueba.AddCell(clSexo);
            tblPrueba.AddCell(clEspecie);
            tblPrueba.AddCell(clRaza);

            clNombre = new PdfPCell(new Phrase(" ", _standardFont));
            clNombre.BorderWidth = 0.5f;

            clEdad = new PdfPCell(new Phrase(" ", _standardFont));
            clEdad.BorderWidth = 0.5f;

            clSexo = new PdfPCell(new Phrase(" ", _standardFont));
            clSexo.BorderWidth = 0.5f;

            clEspecie = new PdfPCell(new Phrase(" ", _standardFont));
            clEspecie.BorderWidth = 0.5f;

            clRaza = new PdfPCell(new Phrase(" ", _standardFont));
            clRaza.BorderWidth = 0.5f;

            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clEdad);
            tblPrueba.AddCell(clSexo);
            tblPrueba.AddCell(clEspecie);
            tblPrueba.AddCell(clRaza);

            doc.Add(tblPrueba);

            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Phrase("2ª El Adoptante declara adoptar al animal única y exclusivamente como animal de compañía."));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Phrase("( ) A recoger en protectora : "));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Phrase("( ) Envio a dirección : "));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);

            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("( ) Me comprometo a cuidar, dar mimo y cariño todos los días a mi nueva mascota, cumpliendo con las responsabilidaddes que ello conlleva. Para verificar esto, acepto un seguimiento durante el tiempo que la protectora considere"));
            doc.Add(Chunk.NEWLINE);
            doc.Add(Chunk.NEWLINE);
            doc.Add(new Phrase("Firma Adoptante:                                                                       Firma Protectora:"));
            doc.Add(Chunk.NEWLINE);

            //writer.Close();
            doc.Close();
            file.Dispose();

            var pdf = new FileStream(ruta, FileMode.Open, FileAccess.Read);

            return File(pdf, "application/pdf");
        }

        // GET: ContratoAdopcion/Edit/5
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

            ContratoAdopcionViewModel con = null;

            SessionInitialize();

            ContratoAdopcionEN conEN = new ContratoAdopcionCAD(session).Ver_Contrato(id);

            con = new ContratoAdopcionAssembler().ConvertENToModelUI(conEN);

            SessionClose();

            return View(con);
        }

        // POST: ContratoAdopcion/Edit/5
        [HttpPost]
        public ActionResult Edit(ContratoAdopcionViewModel con, HttpPostedFileBase fileEscritura, HttpPostedFileBase justipago)
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

            string filenameEscritura = "";
            string rutaEscritura = "";
            if(fileEscritura != null && fileEscritura.ContentLength > 0)
            {
                filenameEscritura = Path.GetFileName(fileEscritura.FileName);
                rutaEscritura = Path.Combine(Server.MapPath("~/Contratos/escrituras/"), filenameEscritura);
                fileEscritura.SaveAs(rutaEscritura);
            }
            string filenamePago = "";
            string rutaPago = "";
            if(justipago != null && justipago.ContentLength > 0)
            {
                filenamePago = Path.GetFileName(justipago.FileName);
                rutaPago = Path.Combine(Server.MapPath("~/Contratos/jusPagos/"), filenamePago);
                justipago.SaveAs(rutaPago);
            }
            try
            {
                // TODO: Add update logic here

                filenameEscritura = "Contratos/escrituras/" + filenameEscritura;
                filenamePago = "Contratos/jusPagos/" + filenamePago;

                ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN();

                conCEN.Rellenar_Contrato(con.Id, con.Nombre, con.DNI_NIF_Pasaporte, filenameEscritura, filenamePago, con.LugarRecojida, con.FirmaCompromiso);
                //con.EscrituraHogar;
                TempData["mensajeModal"] = "Los datos se han actualizado";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

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

            SessionInitialize();

            ContratoAdopcionViewModel con = null;

            ContratoAdopcionEN conEN = new ContratoAdopcionCAD(session).Ver_Contrato(id);

            con = new ContratoAdopcionAssembler().ConvertENToModelUI(conEN);

            SessionClose();

            return View(con);
        }

        // POST: ContratoAdopcion/Edit/5
        [HttpPost]
        public ActionResult ActualizarEstado(ContratoAdopcionViewModel con)
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
                ContratoAdopcionCP conCP = new ContratoAdopcionCP();

                conCP.Actualizar_Estado(con.Id, con.Estado);

                TempData["mensajeModal"] = "El estado del contrato ha sido actualizado";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ObtenerContratoUsuario(string email, int? page, string sortOrder, string nameSearch, string usuSearch, string aniSearch)
        {
            SessionInitialize();

            ContratoAdopcionCAD conCAD = new ContratoAdopcionCAD(session);
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN(conCAD);

            IList<ContratoAdopcionEN> listaConEN = conCEN.Obtener_Contrato_Usuario(email);

            ViewBag.NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.UsuSort = String.IsNullOrEmpty(sortOrder) ? "usu_desc" : "";
            ViewBag.AniSort = String.IsNullOrEmpty(sortOrder) ? "ani_desc" : "";

            if (!String.IsNullOrEmpty(nameSearch))
            {
                listaConEN = listaConEN.Where(s => s.Nombre.Contains(nameSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(usuSearch))
            {
                listaConEN = listaConEN.Where(s => s.Usuario.Nombre.Contains(usuSearch)).ToList();
            }

            if (!String.IsNullOrEmpty(aniSearch))
            {
                listaConEN = listaConEN.Where(s => s.Animal.Nombre.Contains(aniSearch)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    listaConEN = listaConEN.OrderByDescending(s => s.Nombre).ToList();
                    break;
                case "usu_desc":
                    listaConEN = listaConEN.OrderByDescending(s => s.Usuario.Nombre).ToList();
                    break;
                case "ani_desc":
                    listaConEN = listaConEN.OrderByDescending(s => s.Animal.Nombre).ToList();
                    break;
                default:
                    listaConEN = listaConEN.OrderBy(s => s.Nombre).ToList();
                    break;
            }

            IEnumerable<ContratoAdopcionViewModel> listaCon = new ContratoAdopcionAssembler().ConvertListENToModel(listaConEN).ToList();

            UsuarioEN usuEN = usuCAD.Dame_Por_Email(email);

            ViewData["idUsuario"] = email;

            if (usuEN != null)
            {
                ViewData["NombreUsuario"] = usuEN.Nombre;
            }


            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaCon.ToPagedList(pageNumber, pageSize));
        }

        //GET
        public ActionResult contratoRellenar(int idCon)
        {

            
            TempData["idCon"] = idCon;

            return View();
        }

        //POST
        [HttpPost]
        public ActionResult contratoRellenar(ContratoAdopcionViewModel con, HttpPostedFileBase fileEscritura, HttpPostedFileBase justipago)
        {
            string filenameEscritura = "";
            string rutaEscritura = "";
            if (fileEscritura != null && fileEscritura.ContentLength > 0)
            {
                filenameEscritura = Path.GetFileName(fileEscritura.FileName);
                rutaEscritura = Path.Combine(Server.MapPath("~/Contratos/escrituras/"), filenameEscritura);
                fileEscritura.SaveAs(rutaEscritura);
            }
            string filenamePago = "";
            string rutaPago = "";
            if (justipago != null && justipago.ContentLength > 0)
            {
                filenamePago = Path.GetFileName(justipago.FileName);
                rutaPago = Path.Combine(Server.MapPath("~/Contratos/jusPagos/"), filenamePago);
                justipago.SaveAs(rutaPago);
            }
            try
            {
                // TODO: Add update logic here

                filenameEscritura = "Contratos/escrituras/" + filenameEscritura;
                filenamePago = "Contratos/jusPagos/" + filenamePago;
                ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN();
                SessionInitialize();
                UsuarioEN usuen = ((UsuarioEN)Session["Usuario"]);
                SolicitudAdopcionCAD soliCAD = new SolicitudAdopcionCAD(session);
                SolicitudAdopcionCEN soliCEN = new SolicitudAdopcionCEN(soliCAD);
               

                

                conCEN.Rellenar_Contrato((int)TempData["idCon"], con.Nombre, con.DNI_NIF_Pasaporte, filenameEscritura, filenamePago, con.LugarRecojida, con.FirmaCompromiso);
                //con.EscrituraHogar;
                SessionClose();
                TempData["mensajeModal"] = "¡Enhorabuena!, Has creado el contrato con éxito, haga click en el enlace de abajo para descargarlo";
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

            // GET: ContratoAdopcion/Delete/5
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
            ContratoAdopcionCAD conCad = new ContratoAdopcionCAD(session);
            ContratoAdopcionCEN contCEN = new ContratoAdopcionCEN(conCad);
            ViewData["IdCon"] = id;
            ViewData["NombreCon"] = contCEN.Ver_Contrato(id).Nombre;

            SessionClose();
            return View();
        }

        // POST: ContratoAdopcion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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

                ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN();

                conCEN.Eliminar(id);
                TempData["mensajeModal"] = "El contrato ha sido eliminado";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModal"] = "Ha habido un error al eliminar el contrato";
                return RedirectToAction("Index");
            }
        }
    }
}