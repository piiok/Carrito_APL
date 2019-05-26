using System;
using System.IO; //Manejo archivos
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
    public class ProductosController : Controller
    {
        private db_carrito_apl_Entities db = new db_carrito_apl_Entities();
        private string _PATH = "D:/Documentos/UIS/Encargos/GrupoAPL/Carrito_APL/carrito_apl_proyecto/carrito_apl_proyecto/Content/images/productos/";
        private string _PATH2 = "/Content/images/productos/";

        // GET: /Productos/
        public ActionResult Index()
        {
            var productos = db.productos.Include(p => p.categorias).Include(p => p.transportes);
            return View(productos.ToList());
        }

        // GET: /Productos/Details/5
        public ActionResult Details(int? id)
        {   
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }else{
                try
                {
                    ViewBag.fotos = Directory.GetFiles(_PATH + productos.fotos).Select(f => _PATH2 + productos.fotos + System.IO.Path.GetFileName(f)).ToList();
                }catch(Exception e){
                    throw e;
                }          
            }
            return View(productos);
        }

        // GET: /Productos/Create
        public ActionResult Create()
        {
            ViewBag.fk_categoria = new SelectList(db.categorias, "pk_categoria", "nombre");
            ViewBag.fk_transporte = new SelectList(db.transportes, "pk_transporte", "nombre");
            return View();
        }

        // POST: /Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="pk_producto,fk_transporte,fk_categoria,fotos,descuento,precio,existencias,titulo,descripcion")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_categoria = new SelectList(db.categorias, "pk_categoria", "nombre", productos.fk_categoria);
            ViewBag.fk_transporte = new SelectList(db.transportes, "pk_transporte", "nombre", productos.fk_transporte);
            return View(productos);
        }

        // GET: /Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_categoria = new SelectList(db.categorias, "pk_categoria", "nombre", productos.fk_categoria);
            ViewBag.fk_transporte = new SelectList(db.transportes, "pk_transporte", "nombre", productos.fk_transporte);
            return View(productos);
        }

        // POST: /Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="pk_producto,fk_transporte,fk_categoria,fotos,descuento,precio,existencias,titulo,descripcion")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_categoria = new SelectList(db.categorias, "pk_categoria", "nombre", productos.fk_categoria);
            ViewBag.fk_transporte = new SelectList(db.transportes, "pk_transporte", "nombre", productos.fk_transporte);
            return View(productos);
        }

        // GET: /Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: /Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productos productos = db.productos.Find(id);
            db.productos.Remove(productos);
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
