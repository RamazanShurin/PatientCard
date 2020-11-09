using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatientCart.Models;

namespace PatientCart.Controllers
{
    public class VisitHistoriesController : Controller
    {
        private PatientCardEntities db = new PatientCardEntities();

        // GET: VisitHistories
        public async Task<ActionResult> Index(string patientName = null)
        {
            
            var visitHistories = await db.VisitHistories.Include(v => v.Diagnoses).Include(v => v.Doctors).Include(v => v.Patients).ToListAsync();
            if (patientName != null) {
                visitHistories = visitHistories.Where(v => Convert.ToString(v.Patients.IIN) == patientName
                || v.Patients.LastName.ToLower().Contains(patientName.ToLower()) || v.Patients.FirstName.ToLower().Contains(patientName.ToLower()) || v.Patients.PatronymicName.ToLower().Contains(patientName.ToLower())
                || patientName.ToLower().Contains(v.Patients.LastName.ToLower()) || patientName.ToLower().Contains(v.Patients.FirstName.ToLower()) || patientName.ToLower().Contains(v.Patients.PatronymicName.ToLower())
                ).ToList();
            }
            return View(visitHistories);
        }

        // GET: VisitHistories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitHistories visitHistories = await db.VisitHistories.FindAsync(id);
            if (visitHistories == null)
            {
                return HttpNotFound();
            }
            return View(visitHistories);
        }

        // GET: VisitHistories/Create
        public ActionResult Create()
        {
            ViewBag.DiagnosisId = new SelectList(db.Diagnoses, "Id", "Title");
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "LastName");
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "LastName");
            return PartialView();
        }

        // POST: VisitHistories/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Complaints,VisitDate,DoctorId,PatientId,DiagnosisId")] VisitHistories visitHistories)
        {
            if (ModelState.IsValid)
            {
                db.VisitHistories.Add(visitHistories);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            ViewBag.DiagnosisId = new SelectList(db.Diagnoses, "Id", "Title", visitHistories.DiagnosisId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "LastName", visitHistories.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "LastName", visitHistories.PatientId);
            return View(visitHistories);
        }

        // GET: VisitHistories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitHistories visitHistories = await db.VisitHistories.FindAsync(id);
            if (visitHistories == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiagnosisId = new SelectList(db.Diagnoses, "Id", "Title", visitHistories.DiagnosisId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "LastName", visitHistories.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "LastName", visitHistories.PatientId);
            return PartialView(visitHistories);
        }

        // POST: VisitHistories/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Complaints,VisitDate,DoctorId,PatientId,DiagnosisId")] VisitHistories visitHistories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitHistories).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DiagnosisId = new SelectList(db.Diagnoses, "Id", "Title", visitHistories.DiagnosisId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "LastName", visitHistories.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "Id", "LastName", visitHistories.PatientId);
            return View(visitHistories);
        }

        // GET: VisitHistories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitHistories visitHistories = await db.VisitHistories.FindAsync(id);
            if (visitHistories == null)
            {
                return HttpNotFound();
            }
            return View(visitHistories);
        }

        // POST: VisitHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VisitHistories visitHistories = await db.VisitHistories.FindAsync(id);
            db.VisitHistories.Remove(visitHistories);
            await db.SaveChangesAsync();
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
