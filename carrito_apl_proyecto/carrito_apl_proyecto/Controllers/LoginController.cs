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
        // GET: /Login?error
        public ActionResult Index()
        {
            if (Session["id"] == null)
            {
                ViewBag.error = Convert.ToString(Request.QueryString["error"]);
                return View();
            }
            else {
                return RedirectToRoute("Default", new { controller = "Home", action = "Index"});
            }
        }

        //
        // POST: /Login/LoginVerify
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginVerify(FormCollection form)
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    System.Diagnostics.Debug.WriteLine("FOR ->IP!!!!!! " + addresses[0]);
                }
            }

            var ipList = context.Request.ServerVariables["REMOTE_ADDR"];

            System.Diagnostics.Debug.WriteLine("IP!!!!!! "+ipList);

            string pk_comprador = Convert.ToString(form["pk_comprador"]);
            string password = Convert.ToString(form["password"]);

            using (db_carrito_apl_Entities db = new db_carrito_apl_Entities())
            {
                
                var query = from c in db.compradores
                            where c.pk_comprador == pk_comprador && c.password == password
                            select c;

                if (query.Count() != 1 ) {
                    return RedirectToRoute("Default", new { controller = "Login", action = "Index", error = "La contraseña o la cédula no es válida." });
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
