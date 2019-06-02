using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using carrito_apl_proyecto.Models;
using System.Data;
using System.Data.Entity;
using System.Net;

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
            string ip = getIP();
            string pk_comprador = Convert.ToString(form["pk_comprador"]);
            string password = Convert.ToString(form["password"]);

            using (db_carrito_apl_Entities db = new db_carrito_apl_Entities())
            {
                
                var query = from c in db.compradores
                            where c.pk_comprador == pk_comprador && c.password == password
                            select c;

                if (query.Count() != 1 ) {
                    return RedirectToRoute("Default", new { controller = "Login", action = "Index", error = "La contraseña o la cédula no es válida." });
                } else {
                    foreach (var c in query){
                        System.Diagnostics.Debug.WriteLine("Logeado: " + c.pk_comprador);
                        Session["id"] = c.pk_comprador;
                        Session["nombres"] = c.nombres;
                        Session["apellidos"] = c.apellidos;
                    }
                    
                }

            }
            using (db_carrito_apl_Entities db2 = new db_carrito_apl_Entities())
            {
                if (ModelState.IsValid && Session["id"] != null)
                {
                    sesiones sesion = new sesiones();
                    sesion.ip = ip;
                    sesion.fk_comprador = pk_comprador;

                    sesion.fecha_login = DateTime.Now;
                    db2.sesiones.Add(sesion);
                    db2.SaveChanges();
                    Session["id_sesion"] = sesion.pk_sesiones;
                }
            }
            return RedirectToRoute("Default", new { controller = "Home", action = "Index" });
        }


        public ActionResult LogOut()
        {
            db_carrito_apl_Entities db = new db_carrito_apl_Entities();
            FormsAuthentication.SignOut();
            Session.Abandon();
            if (ModelState.IsValid)
            {
                sesiones sesion = db.sesiones.Find(Session["id_sesion"]);
                if (sesion != null)
                {
                    sesion.fecha_logout = DateTime.Now;
                    db.Entry(sesion).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else { System.Diagnostics.Debug.WriteLine("Se intenta cerrar una sesion inexistente. Login->LogOut"); }
                
            }
            return RedirectToAction("index", "login");
        }

        private string getIP() {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    System.Diagnostics.Debug.WriteLine("Inicio sesion en la ip:  " + addresses[0]);
                    return addresses[0];
                }
            }

            var ipList = context.Request.ServerVariables["REMOTE_ADDR"];

            System.Diagnostics.Debug.WriteLine("Inicio sesion en la ip:  " + ipList);
            return ipList;
        }

    }
}
