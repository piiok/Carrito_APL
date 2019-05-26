using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using carrito_apl_proyecto.Models;

namespace carrito_apl_proyecto.Controllers
{
    public class LoginController : Controller
    {

        //
        // GET: /Login/
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                return View();
            }
            else {
                return RedirectToRoute("Default", new { controller = "Home", action = "Index"});
            }
        }

        //
        // POST: /Login/LoginVerify
        [HttpPost]
        public ActionResult LoginVerify(FormCollection form)
        {
            string pk_comprador = Convert.ToString(form["pk_comprador"]);
            string password = Convert.ToString(form["password"]);

            using (db_carrito_apl_Entities db = new db_carrito_apl_Entities())
            {
                
                var query = from c in db.compradores
                            where c.pk_comprador == pk_comprador && c.password == password
                            select c;

                System.Diagnostics.Debug.WriteLine(pk_comprador + "Hello");
                if (query.Count() != 1 ) {
                    throw new Exception("El numero de coincidencias es diferente de 1. Coincidencias: "+query.Count());
                }
                else {
                    foreach (var c in query){
                        System.Diagnostics.Debug.WriteLine("Logeado: " + c.pk_comprador);
                        Session["id"] = c.pk_comprador;
                        Session["nombres"] = c.nombres;
                        Session["apellidos"] = c.apellidos;
                    }
                }
               

            }
            return RedirectToRoute("Default", new { controller = "Home", action = "Index" });
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("index", "login");
        }


    }
}
