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
            var registro = db.Registro.Include(r => r.tblDatosHorarios).Include(r => r.tblEmpleados);
            return View(registro.ToList());
        }

        // GET: RegistroHorarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroHorarios registroHorarios = db.Registro.Where(r=>r.Id == id).Include(r=> r.tblEmpleados).Include(r=>r.tblDatosHorarios).FirstOrDefault();
            if (registroHorarios == null)
            {
                return HttpNotFound();
            }
            return View(registroHorarios);
        }

        // GET: RegistroHorarios/Create
        public ActionResult Create()
        {
            ViewBag.tblDatosHorariosId = new SelectList(db.Horarios, "Id", "TipoHorario");
            ViewBag.tblEmpleadosId = new SelectList(db.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: RegistroHorarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,tblEmpleadosId,tblDatosHorariosId,Fecha2,Horas")] RegistroHorarios registroHorarios)
        {
            if (ModelState.IsValid)
            {
                db.Registro.Add(registroHorarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tblDatosHorariosId = new SelectList(db.Horarios, "Id", "TipoHorario", registroHorarios.tblDatosHorariosId);
            ViewBag.tblEmpleadosId = new SelectList(db.Empleados, "Id", "Nombre", registroHorarios.tblEmpleadosId);
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
            ViewBag.tblDatosHorariosId = new SelectList(db.Horarios, "Id", "TipoHorario", registroHorarios.tblDatosHorariosId);
            ViewBag.tblEmpleadosId = new SelectList(db.Empleados, "Id", "Nombre", registroHorarios.tblEmpleadosId);
            return View(registroHorarios);
        }

        // POST: RegistroHorarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,tblEmpleadosId,tblDatosHorariosId,Fecha2,Horas")] RegistroHorarios registroHorarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroHorarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tblDatosHorariosId = new SelectList(db.Horarios, "Id", "TipoHorario", registroHorarios.tblDatosHorariosId);
            ViewBag.tblEmpleadosId = new SelectList(db.Empleados, "Id", "Nombre", registroHorarios.tblEmpleadosId);
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

        public ActionResult Salario(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            var registroHorario = db.Registro.Where(e=>e.Id == id).Include(e=>e.tblDatosHorarios).Include(e=>e.tblEmpleados).FirstOrDefault();
            SalarioEmpleado salarioEmpleadito = new SalarioEmpleado();
            salarioEmpleadito.Nombre = registroHorario.tblEmpleados.Nombre;
            salarioEmpleadito.Horas = registroHorario.tblDatosHorarios.CantidadHoras;

            double horasTrabajas = registroHorario.tblDatosHorarios.CantidadHoras - registroHorario.Horas;
            double horasNormales = registroHorario.tblDatosHorarios.CantidadHoras - horasTrabajas;
            double horasExtra = (horasTrabajas < 0) ? horasTrabajas * -1 : 0;
            decimal Salario = (decimal)((horasNormales * registroHorario.tblDatosHorarios.CostoNormal) + (horasExtra * registroHorario.tblDatosHorarios.CostoExtra));

            salarioEmpleadito.Horas = horasNormales;
            salarioEmpleadito.HorasExtra = horasExtra;
            salarioEmpleadito.Salario = Salario;

            return View(salarioEmpleadito);
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
