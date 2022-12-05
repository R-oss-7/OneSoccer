using OneSoccer.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneSoccer.Controllers
{
    public class EstadisticaController : Controller
    {
        // GET: Estadistica
       

        public ActionResult Index()
        {
            List<Estadistica> estadisticas = Estadistica.GetAll();
            return View(estadisticas);
        }

        public ActionResult VerEstadisticas(int id)
        {
            List<Estadistica> estadisticas = Estadistica.EstadisticaByJugador(id);
            return View("Index", estadisticas);
        }

        public ActionResult Registro(int id)
        {
            Estadistica estadistica = Estadistica.GetById(id);
            return View(estadistica);
        }
    }
}