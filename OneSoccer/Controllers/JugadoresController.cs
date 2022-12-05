using OneSoccer.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneSoccer.Controllers
{
    public class JugadoresController : Controller
    {
        // GET: Jugadores
        public ActionResult Index()
        {
            List<Jugador> jugadores = Jugador.GetAll();
            return View(jugadores);
        }

        public ActionResult VerJugadores(int id)
        {
            List<Jugador> jugadores = Jugador.JugadorByEquipo(id);
            return View("Index", jugadores);
        }

        public ActionResult Registro(int id)
        {
            Jugador jugador = Jugador.GetById(id);
            return View(jugador);
        }

        public ActionResult Guardar(int id, string nombre, string apellido, string posicion, int numero, string nacionalidad, int edad, Equipo equipo)
        {
            Jugador.Guardar(id, nombre, apellido, posicion, numero, nacionalidad, edad, equipo);
            return RedirectToAction("index");
        }

        public ActionResult Eliminar(int id)
        {
            Liga.Eliminar(id);
            return RedirectToAction("index");
        }


    }
}