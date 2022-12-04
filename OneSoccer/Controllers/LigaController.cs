using OneSoccer.core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneSoccer.Controllers
{
    public class LigaController : Controller
    {
        // GET: Liga
        public ActionResult Index()
        {
            List<Liga> ligas = Liga.GetAll();
            return View(ligas);
        }

        public ActionResult Registro(int id)
        {
            Liga liga = Liga.GetById(id);
            return View(liga);
        }

        public ActionResult Guardar(int id, string nombre, string pais)
        {
            Liga.Guardar(id, nombre, pais);
            return RedirectToAction("index");
        }

        public ActionResult Eliminar(int id)
        {
            Liga.Eliminar(id);
            return RedirectToAction("index");
        }
    }
}