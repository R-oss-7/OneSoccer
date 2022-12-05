using OneSoccer.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneSoccer.Controllers
{
    public class EquipoController : Controller
    {
        // GET: Equipo
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult VerEquipos(int id)
        {
            List<Equipo> equipos = Equipo.EquipoByLiga(id);
            return View("Index", equipos);
        }
        public ActionResult Registro(int id)
        {
            Equipo equipo = Equipo.GetById(id);
            return View(equipo);
        }

        public ActionResult Guardar(int id, string nombre,string estadio, string pais, string entrenador, string presidente)
        {
            Equipo.Guardar(id, nombre,estadio, pais, entrenador, presidente);
            return RedirectToAction("index");
        }
    }

}