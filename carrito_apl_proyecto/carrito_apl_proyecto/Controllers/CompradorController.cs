using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using carrito_apl_proyecto.Models;

namespace carrito_apl_proyecto.Controllers
{
    public class CompradorController : Controller
    {
        private db_carrito_apl_Entities db = new db_carrito_apl_Entities();


        // GET: /Comprador/Details
        public ActionResult Details()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("index", "login");
            }
            var id = Session["id"];
            compradores compradores = db.compradores.Find(id);

            if (compradores == null)
            {
                return HttpNotFound();
            }
            return View(compradores);
        }

        // GET: /Comprador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Comprador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="pk_comprador,nombres,apellidos,fecha_nacimiento,tipo_documento,celular,genero,password")] compradores compradores)
        {
            if (ModelState.IsValid)
            {
                db.compradores.Add(compradores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compradores);
        }

        // GET: /Comprador/Edit/5
        public ActionResult Edit()
        {
            if (Session["id"] == null)
            {
                return RedirectToAction("index", "login");
            }
            var id = Session["id"];
            compradores compradores = db.compradores.Find(id);
            if (compradores == null)
            {
                return HttpNotFound();
            }
            return View(compradores);
        }

        // POST: /Comprador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="pk_comprador,nombres,apellidos,fecha_nacimiento,tipo_documento,celular,genero,password")] compradores compradores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compradores).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compradores);
        }

        // GET: /Comprador/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            compradores compradores = db.compradores.Find(id);
            if (compradores == null)
            {
                return HttpNotFound();
            }
            return View(compradores);
        }

        // POST: /Comprador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            compradores compradores = db.compradores.Find(id);
            db.compradores.Remove(compradores);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
