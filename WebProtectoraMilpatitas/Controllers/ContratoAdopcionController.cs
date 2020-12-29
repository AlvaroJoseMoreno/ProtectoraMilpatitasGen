using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
        public ActionResult Index()
        {
            SessionInitialize();

            ContratoAdopcionCAD conCAD = new ContratoAdopcionCAD(session);
            ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN(conCAD);

            IList<ContratoAdopcionEN> contsEN = conCEN.Dame_Todos(0, -1);

            IEnumerable<ContratoAdopcionViewModel> listaContratos = new ContratoAdopcionAssembler().ConvertListENToModel(contsEN).ToList();

            SessionClose();

            return View(listaContratos);
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
            try
            {
                // TODO: Add insert logic here
                ContratoAdopcionCEN contCEN = new ContratoAdopcionCEN();

                //ver como pasar el animal y el usuario
                contCEN.Nuevo(con.idUsuario, con.idSolicitud, con.idAnimal);

                return RedirectToAction("Imprimir");
            }
            catch
            {
                return View();
            }
        }

        public FileResult Imprimir()
        {
            Document doc = new Document(PageSize.LETTER);
            string ruta = Path.Combine(Server.MapPath("~/Imagenes"), "holamundo1.pdf");
            FileStream file = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            PdfWriter writer = PdfWriter.GetInstance(doc, file);

            doc.AddAuthor("ProtectoraMilpatitas");
            doc.AddTitle("Contrato Adopcion");
            doc.Open();
            doc.Add(new Phrase("Soy una prueba de contrato"));

            //writer.Close();
            doc.Close();
            file.Dispose();

            var pdf = new FileStream(ruta, FileMode.Open, FileAccess.Read);

            return File(pdf, "application/pdf");
        }

        // GET: ContratoAdopcion/Edit/5
        public ActionResult Edit(int id)
        {
            ContratoAdopcionViewModel con = null;

            SessionInitialize();

            ContratoAdopcionEN conEN = new ContratoAdopcionCAD(session).Ver_Contrato(id);

            con = new ContratoAdopcionAssembler().ConvertENToModelUI(conEN);

            SessionClose();

            return View(con);
        }

        // POST: ContratoAdopcion/Edit/5
        [HttpPost]
        public ActionResult Edit(ContratoAdopcionViewModel con)
        {
            try
            {
                // TODO: Add update logic here
                ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN();

                conCEN.Rellenar_Contrato(con.Id, con.Nombre, con.DNI_NIF_Pasaporte, con.EscrituraHogar, con.JustificantePago, con.LugarRecojida, con.FirmaCompromiso);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ActualizarEstado(int id)
        {
            ContratoAdopcionViewModel con = null;

            SessionInitialize();

            ContratoAdopcionEN conEN = new ContratoAdopcionCAD(session).Ver_Contrato(id);

            con = new ContratoAdopcionAssembler().ConvertENToModelUI(conEN);

            SessionClose();

            return View(con);
        }

        // POST: ContratoAdopcion/Edit/5
        [HttpPost]
        public ActionResult ActualizarEstado(ContratoAdopcionViewModel con)
        {
            try
            {
                // TODO: Add update logic here
                ContratoAdopcionCP conCP = new ContratoAdopcionCP();

                conCP.Actualizar_Estado(con.Id, con.Estado);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ObtenerContratoUsuario(string email)
        {
            SessionInitialize();

            ContratoAdopcionCAD conCAD = new ContratoAdopcionCAD(session);
            UsuarioCAD usuCAD = new UsuarioCAD(session);
            ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN(conCAD);

            IList<ContratoAdopcionEN> listaConEN = conCEN.Obtener_Contrato_Usuario(email);

            IEnumerable<ContratoAdopcionViewModel> listaCon = new ContratoAdopcionAssembler().ConvertListENToModel(listaConEN).ToList();

            UsuarioEN usuEN = usuCAD.Dame_Por_Email(email);

            ViewData["idUsuario"] = email;

            if (usuEN != null)
            {
                ViewData["NombreUsuario"] = usuEN.Nombre;
            }


            SessionClose();

            return View(listaCon);
        }

        // GET: ContratoAdopcion/Delete/5
        public ActionResult Delete(int id)
        {
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
            try
            {
                // TODO: Add delete logic here

                ContratoAdopcionCEN conCEN = new ContratoAdopcionCEN();

                conCEN.Eliminar(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}