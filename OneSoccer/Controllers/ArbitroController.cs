using OneSoccer.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneSoccer.Controllers
{
    public class ArbitroController : Controller
    {
        // GET: Arbitro
        public ActionResult Index()
        {
            List<Arbitro> arbitros = Arbitro.GetAll();
            return View(arbitros);
        }

        public ActionResult Registro(int id)
        {
            Arbitro arbitro = Arbitro.GetById(id);
            return View(arbitro);
        }

        public ActionResult Guardar(int id, string nombre, string pais, int edad, string posicion, Liga liga)
        {
            Arbitro.Guardar(id, nombre, pais, edad, posicion, liga);
            return RedirectToAction("index");
        }

        public ActionResult Eliminar(int id)
        {
            Liga.Eliminar(id);
            return RedirectToAction("index");

        }

        public ActionResult VerArbitros(int id)
        {
            List<Arbitro> arbitros = Arbitro.arbitroByLiga(id);
            return View("Index", arbitros);
        }
    }
}