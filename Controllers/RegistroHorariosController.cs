using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Veterinaria.Models;

namespace Proyecto_Veterinaria.Controllers
{
    public class RegistroHorariosController : Controller
    {
        private EmpresaDBContext db = new EmpresaDBContext();

        // GET: RegistroHorarios
        public ActionResult Index()
        {
            return View(db.Registro.ToList());
        }

        // GET: RegistroHorarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroHorarios registroHorarios = db.Registro.Find(id);
            if (registroHorarios == null)
            {
                return HttpNotFound();
            }
            return View(registroHorarios);
        }

        // GET: RegistroHorarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistroHorarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre2,HorarioDefi,Fecha2,HorasExtras")] RegistroHorarios registroHorarios)
        {
            if (ModelState.IsValid)
            {
                db.Registro.Add(registroHorarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registroHorarios);
        }

        // GET: RegistroHorarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroHorarios registroHorarios = db.Registro.Find(id);
            if (registroHorarios == null)
            {
                return HttpNotFound();
            }
            return View(registroHorarios);
        }

        // POST: RegistroHorarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre2,HorarioDefi,Fecha2,HorasExtras")] RegistroHorarios registroHorarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroHorarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registroHorarios);
        }

        // GET: RegistroHorarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroHorarios registroHorarios = db.Registro.Find(id);
            if (registroHorarios == null)
            {
                return HttpNotFound();
            }
            return View(registroHorarios);
        }

        // POST: RegistroHorarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroHorarios registroHorarios = db.Registro.Find(id);
            db.Registro.Remove(registroHorarios);
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
