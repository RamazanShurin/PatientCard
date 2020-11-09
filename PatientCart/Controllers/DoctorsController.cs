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
    public class DoctorsController : Controller
    {
        private PatientCardEntities db = new PatientCardEntities();

        // GET: Doctors
        public async Task<ActionResult> Index()
        {
            var doctors = db.Doctors.Include(d => d.Specializations);
            return View(await doctors.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = await db.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Title");
            return View();
        }

        // POST: Doctors/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,LastName,FirstName,PatronymicName,SpecializationId")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctors);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Title", doctors.SpecializationId);
            return View(doctors);
        }

        // GET: Doctors/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = await db.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Title", doctors.SpecializationId);
            return View(doctors);
        }

        // POST: Doctors/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,LastName,FirstName,PatronymicName,SpecializationId")] Doctors doctors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctors).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "Id", "Title", doctors.SpecializationId);
            return View(doctors);
        }

        // GET: Doctors/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctors doctors = await db.Doctors.FindAsync(id);
            if (doctors == null)
            {
                return HttpNotFound();
            }
            return View(doctors);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Doctors doctors = await db.Doctors.FindAsync(id);
            db.Doctors.Remove(doctors);
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
