using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using System.Net;
using carrito_apl_proyecto.Models;

namespace carrito_apl_proyecto.Controllers
{
    public class HomeController : Controller
    {
        private db_carrito_apl_Entities db = new db_carrito_apl_Entities();
        public ActionResult Index()
        {
            var productos = db.productos.Include(p => p.categorias).Include(p => p.transportes);
            return View(productos.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}