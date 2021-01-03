using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.CEN.ProtectoraMilpatitas;
using ProtectoraMilpatitasGenNHibernate.EN.ProtectoraMilpatitas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebProtectoraMilpatitas.Assemblers;
using WebProtectoraMilpatitas.Models;
using System.Web.UI.WebControls;

namespace WebProtectoraMilpatitas.Controllers
{
    [Authorize]
    public class TestAnimalIdealController : BasicController
    {
        // GET: TestAnimalIdeal
        public ActionResult Index(int? page)
        {
            SessionInitialize();

            TestAnimalIdealCAD testCAD = new TestAnimalIdealCAD(session);
            TestAnimalIdealCEN testCEN = new TestAnimalIdealCEN(testCAD);

            IList<TestAnimalIdealEN> listEN = testCEN.Dame_Todos(0, -1);
            IEnumerable<TestAnimalIdealViewModel> listView = new TestAnimalIdealAssembler().ConvertListENToModel(listEN).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listView.ToPagedList(pageNumber, pageSize));
        }

        // GET: TestAnimalIdeal/Details/5
        public ActionResult Details(int id)
        {
            SessionInitialize();

            TestAnimalIdealViewModel test = null;
            TestAnimalIdealEN testEN = new TestAnimalIdealCAD(session).Ver_Resultado(id);
            test = new TestAnimalIdealAssembler().ConvertENToModelUI(testEN);

            SessionClose();

            return View(test);
        }

        public ActionResult VerResultado(int id)
        {
            SessionInitialize();

            TestAnimalIdealCAD testCAD = new TestAnimalIdealCAD(session);
            TestAnimalIdealCEN testCEN = new TestAnimalIdealCEN(testCAD);

            ViewData["IdTest"] = id;
            ViewData["NombreTest"] = testCEN.Ver_Resultado(id).Usuario.Nombre;

            TestAnimalIdealViewModel test = null;
            TestAnimalIdealEN testEN = new TestAnimalIdealCAD(session).Ver_Resultado(id);
            test = new TestAnimalIdealAssembler().ConvertENToModelUI(testEN);

            SessionClose();

            return View(test);
        }

        // GET: TestAnimalIdeal/Create
        public ActionResult Create()
        {
            IList<UsuarioEN> listausuarios = new UsuarioCEN().Dame_Todos(0, -1);
            IList<SelectListItem> usuariositems = new List<SelectListItem>();

            foreach (UsuarioEN usu in listausuarios)
            {
                usuariositems.Add(new SelectListItem { Text = usu.Nombre, Value = usu.Email });

            }

            ViewData["idUsuario"] = usuariositems;

            return View();
        }

        // POST: TestAnimalIdeal/Create
        [HttpPost]
        public ActionResult Create(TestAnimalIdealViewModel test)
        {
            try
            {
                // TODO: Add insert logic here
                TestAnimalIdealCEN testCEN = new TestAnimalIdealCEN();
                testCEN.Nuevo(test.idUsuario);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestAnimalIdeal/Edit/5
        public ActionResult Edit(int id)
        {
            SessionInitialize();

            TestAnimalIdealViewModel test = null;
            TestAnimalIdealEN testEN = new TestAnimalIdealCAD(session).Ver_Resultado(id);
            test = new TestAnimalIdealAssembler().ConvertENToModelUI(testEN);

            SessionClose();

            return View(test);
        }

        // POST: TestAnimalIdeal/Edit/5
        [HttpPost]
        public ActionResult Edit(TestAnimalIdealViewModel test)
        {
            try
            {
                // TODO: Add update logic here
                TestAnimalIdealCEN testCEN = new TestAnimalIdealCEN();

                testCEN.Rellenar_Test(test.Id, test.AficionFavorita, test.Personalidad, test.ColorFavorito);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TestAnimalIdeal/Edit/5
        public ActionResult RellenarTest()
        {
            //IList<string> listaAficiones = new List<string> { "Animación", "Astrología", "Bailar", "Cantar", "Leer", "Hacer deporte", "Manualidades", "Dibujar" };

            //IList<SelectListItem> aficionesitems = new List<SelectListItem>();
            
            //foreach (string afi in listaAficiones)
            //{
            //    aficionesitems.Add(new SelectListItem { Text = afi, Value = afi });

            //}

            //ViewData["Listaficiones"] = aficionesitems;

            return View();
        }

        // POST: TestAnimalIdeal/Edit/5
        [HttpPost]
        public ActionResult RellenarTest(TestAnimalIdealViewModel test)
        {
            try
            {
                // TODO: Add update logic here
                TestAnimalIdealCEN testCEN = new TestAnimalIdealCEN();

                UsuarioEN usuen = ((UsuarioEN)Session["Usuario"]);

                int idTest=testCEN.Nuevo(usuen.Email);

                testCEN.Rellenar_Test(idTest, test.AficionFavorita, test.Personalidad, test.ColorFavorito);

                TestAnimalIdealEN testEN = testCEN.Ver_Resultado(idTest);
                testEN.Resultado = "Perro";

                return RedirectToAction("VerResultado", new { id = idTest });
            }
            catch
            {
                return View();
            }
        }

        // GET: TestAnimalIdeal/Delete/5
        public ActionResult Delete(int id)
        {
            SessionInitialize();

            TestAnimalIdealCAD testCAD = new TestAnimalIdealCAD(session);
            TestAnimalIdealCEN testCEN = new TestAnimalIdealCEN(testCAD);

            ViewData["IdTest"] = id;
            ViewData["NombreTest"] = testCEN.Ver_Resultado(id).Usuario.Nombre;

            SessionClose();

            return View();
        }

        // POST: TestAnimalIdeal/Delete/5
        [HttpPost]
        public ActionResult Delete(TestAnimalIdealViewModel test)
        {
            try
            {
                // TODO: Add delete logic here
                TestAnimalIdealCEN testCEN = new TestAnimalIdealCEN();
                testCEN.Eliminar(test.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
