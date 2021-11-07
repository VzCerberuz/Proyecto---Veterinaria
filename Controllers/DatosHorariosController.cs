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
    public class DatosHorariosController : Controller
    {
        private EmpresaDBContext db = new EmpresaDBContext();

        // GET: DatosHorarios
        public ActionResult Index()
        {
            var horarios = db.Horarios.Include(d => d.tblEmpleados);
            return View(horarios.ToList());
        }

        // GET: DatosHorarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosHorarios datosHorarios = db.Horarios.Where(e => e.Id == id).Include(d => d.tblEmpleados).FirstOrDefault();
            if (datosHorarios == null)
            {
                return HttpNotFound();
            }
            return View(datosHorarios);
        }

        // GET: DatosHorarios/Create
        public ActionResult Create()
        {
            ViewBag.tblEmpleadosId = new SelectList(db.Empleados, "Id", "Nombre");

            var turnos = new List<SelectListItem> {
                new SelectListItem { Value = "Matutino", Text = "Matutino" },
                new SelectListItem { Value = "Vespertino", Text = "Vespertino" },
                new SelectListItem { Value = "Nocturno", Text = "Nocturno" },
            };

            ViewBag.tiposHorarios = new SelectList(turnos, "Value", "Text");
            return View();
        }

        // POST: DatosHorarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tblEmpleadosId,TipoHorario,CantidadHoras,CostoNormal,CostoExtra")] DatosHorarios datosHorarios)
        {
            if (ModelState.IsValid)
            {
                db.Horarios.Add(datosHorarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tblEmpleadosId = new SelectList(db.Empleados, "Id", "Nombre", datosHorarios.tblEmpleadosId);
            return View(datosHorarios);
        }

        // GET: DatosHorarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosHorarios datosHorarios = db.Horarios.Find(id);
            if (datosHorarios == null)
            {
                return HttpNotFound();
            }

            var turnos = new List<SelectListItem> {
                new SelectListItem { Value = "Matutino", Text = "Matutino" },
                new SelectListItem { Value = "Vespertino", Text = "Vespertino" },
                new SelectListItem { Value = "Nocturno", Text = "Nocturno" },
            };

            ViewBag.tiposHorarios = new SelectList(turnos, "Value", "Text");

            ViewBag.tblEmpleadosId = new SelectList(db.Empleados, "Id", "Nombre", datosHorarios.tblEmpleadosId);
            return View(datosHorarios);
        }

        // POST: DatosHorarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tblEmpleadosId,TipoHorario,CantidadHoras,CostoNormal,CostoExtra")] DatosHorarios datosHorarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosHorarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tblEmpleadosId = new SelectList(db.Empleados, "Id", "Nombre", datosHorarios.tblEmpleadosId);
            return View(datosHorarios);
        }

        // GET: DatosHorarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosHorarios datosHorarios = db.Horarios.Find(id);
            if (datosHorarios == null)
            {
                return HttpNotFound();
            }
            return View(datosHorarios);
        }

        // POST: DatosHorarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosHorarios datosHorarios = db.Horarios.Find(id);
            db.Horarios.Remove(datosHorarios);
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
