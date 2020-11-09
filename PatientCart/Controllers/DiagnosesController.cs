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
    public class DiagnosesController : Controller
    {
        private PatientCardEntities db = new PatientCardEntities();

        // GET: Diagnoses
        public async Task<ActionResult> Index()
        {
            return View(await db.Diagnoses.ToListAsync());
        }

        // GET: Diagnoses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnoses diagnoses = await db.Diagnoses.FindAsync(id);
            if (diagnoses == null)
            {
                return HttpNotFound();
            }
            return View(diagnoses);
        }

        // GET: Diagnoses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diagnoses/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title")] Diagnoses diagnoses)
        {
            if (ModelState.IsValid)
            {
                db.Diagnoses.Add(diagnoses);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(diagnoses);
        }

        // GET: Diagnoses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnoses diagnoses = await db.Diagnoses.FindAsync(id);
            if (diagnoses == null)
            {
                return HttpNotFound();
            }
            return View(diagnoses);
        }

        // POST: Diagnoses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title")] Diagnoses diagnoses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnoses).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(diagnoses);
        }

        // GET: Diagnoses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnoses diagnoses = await db.Diagnoses.FindAsync(id);
            if (diagnoses == null)
            {
                return HttpNotFound();
            }
            return View(diagnoses);
        }

        // POST: Diagnoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Diagnoses diagnoses = await db.Diagnoses.FindAsync(id);
            db.Diagnoses.Remove(diagnoses);
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
