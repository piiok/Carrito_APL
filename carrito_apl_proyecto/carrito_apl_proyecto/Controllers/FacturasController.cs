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
    public class FacturasController : Controller
    {
        private db_carrito_apl_Entities db = new db_carrito_apl_Entities();

        // GET: /Facturas/
        public ActionResult Index()
        {
            var facturas = db.facturas.Include(f => f.compradores).Include(f => f.tarjetas);
            return View(facturas.ToList());
        }

        // GET: /Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            facturas facturas = db.facturas.Find(id);
            if (facturas == null)
            {
                return HttpNotFound();
            }
            return View(facturas);
        }

        // GET: /Facturas/Create
        //public ActionResult Create()
        //{
        //    ViewBag.fk_comprador = new SelectList(db.compradores, "pk_comprador", "nombres");
        //    ViewBag.fk_tarjeta = new SelectList(db.tarjetas, "pk_tarjeta", "fk_comprador");
        //    return View();
        //}

        // POST: /Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="pk_factura,fk_tarjeta,fk_comprador,fecha_pago,total,CVV")] facturas facturas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.facturas.Add(facturas);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.fk_comprador = new SelectList(db.compradores, "pk_comprador", "nombres", facturas.fk_comprador);
        //    ViewBag.fk_tarjeta = new SelectList(db.tarjetas, "pk_tarjeta", "fk_comprador", facturas.fk_tarjeta);
        //    return View(facturas);
        //}

        // GET: /Facturas/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    facturas facturas = db.facturas.Find(id);
        //    if (facturas == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.fk_comprador = new SelectList(db.compradores, "pk_comprador", "nombres", facturas.fk_comprador);
        //    ViewBag.fk_tarjeta = new SelectList(db.tarjetas, "pk_tarjeta", "fk_comprador", facturas.fk_tarjeta);
        //    return View(facturas);
        //}

        // POST: /Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="pk_factura,fk_tarjeta,fk_comprador,fecha_pago,total,CVV")] facturas facturas)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(facturas).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.fk_comprador = new SelectList(db.compradores, "pk_comprador", "nombres", facturas.fk_comprador);
        //    ViewBag.fk_tarjeta = new SelectList(db.tarjetas, "pk_tarjeta", "fk_comprador", facturas.fk_tarjeta);
        //    return View(facturas);
        //}

        //// GET: /Facturas/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    facturas facturas = db.facturas.Find(id);
        //    if (facturas == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(facturas);
        //}

        //// POST: /Facturas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    facturas facturas = db.facturas.Find(id);
        //    db.facturas.Remove(facturas);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
