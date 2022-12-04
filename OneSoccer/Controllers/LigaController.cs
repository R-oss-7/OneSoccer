﻿using OneSoccer.core.Entidades;
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
    }
}