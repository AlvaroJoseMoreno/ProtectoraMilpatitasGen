﻿using ProtectoraMilpatitasGenNHibernate.CAD.ProtectoraMilpatitas;
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

namespace WebProtectoraMilpatitas.Controllers
{
    [Authorize]

    public class EspecieController : BasicController
    {
        // GET: Especie
        public ActionResult Index(int? page)
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

            EspecieCAD especieCAD = new EspecieCAD(session);
            EspecieCEN especieCEN = new EspecieCEN(especieCAD);
            IList<EspecieEN> listaEspecie = especieCEN.Dame_Todas(0, -1);
            IEnumerable<EspecieViewModel> listaView = new EspecieAssembler().ConvertListENToModel(listaEspecie).ToList();

            SessionClose();

            int pageSize = 6;
            int pageNumber = (page ?? 1);

            return View(listaView.ToPagedList(pageNumber, pageSize));
        }

        // GET: Especie/Details/5
        public ActionResult Details(int id)
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
            
            EspecieViewModel esp = null;
            EspecieEN espEN = new EspecieCAD(session).Dame_Por_Id(id);
            esp = new EspecieAssembler().ConvertENToModelUI(espEN);

            SessionClose();
            return View(esp);
        }

        // GET: Especie/Create
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

            return View();
        }

        // POST: Especie/Create
        [HttpPost]
        public ActionResult Create(EspecieViewModel esp)
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

                EspecieCEN espCEN = new EspecieCEN();
                espCEN.Nuevo(esp.Nombre);

                TempData["mensajeModalEspecie"] = "Especie creada correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalEspecie"] = "Ha habido un error al crear la especie";
                return RedirectToAction("Index");
            }
        }

        // GET: Especie/Edit/5
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

            EspecieViewModel esp = null;

            SessionInitialize();
            EspecieEN espEN = new EspecieCAD(session).Dame_Por_Id(id);
            esp = new EspecieAssembler().ConvertENToModelUI(espEN);
            SessionClose();

            return View(esp);
        }

        // POST: Especie/Edit/5
        [HttpPost]
        public ActionResult Edit(EspecieViewModel esp)
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

                EspecieCEN espcen = new EspecieCEN();
                espcen.Modificar(esp.Id, esp.Nombre);

                TempData["mensajeModalEspecie"] = "Especie editada correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalEspecie"] = "Ha habido un error al editar la especie";
                return RedirectToAction("Index");
            }
        }

        // GET: Especie/Delete/5
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
            EspecieCAD espCad = new EspecieCAD(session);
            EspecieCEN especieCEN = new EspecieCEN(espCad);
            ViewData["NombreEsp"] = especieCEN.Dame_Por_Id(id).Nombre;

            SessionClose();
            return View();
        }

        // POST: Especie/Delete/5
        [HttpPost]
        public ActionResult Delete(EspecieViewModel esp)
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
                EspecieCEN especieCEN = new EspecieCEN();
                especieCEN.Eliminar(esp.Id);

                TempData["mensajeModalEspecie"] = "Especie eliminada correctamente";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensajeModalEspecie"] = "Ha habido un error al eliminar la especie";
                return RedirectToAction("Index");
            }
        }
    }
}
