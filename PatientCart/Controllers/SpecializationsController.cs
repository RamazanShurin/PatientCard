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
    public class SpecializationsController : Controller
    {
        private PatientCardEntities db = new PatientCardEntities();

        // GET: Specializations
        public async Task<ActionResult> Index()
        {
            return View(await db.Specializations.ToListAsync());
        }

        // GET: Specializations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specializations specializations = await db.Specializations.FindAsync(id);
            if (specializations == null)
            {
                return HttpNotFound();
            }
            return View(specializations);
        }

        // GET: Specializations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specializations/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title")] Specializations specializations)
        {
            if (ModelState.IsValid)
            {
                db.Specializations.Add(specializations);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(specializations);
        }

        // GET: Specializations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specializations specializations = await db.Specializations.FindAsync(id);
            if (specializations == null)
            {
                return HttpNotFound();
            }
            return View(specializations);
        }

        // POST: Specializations/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title")] Specializations specializations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specializations).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(specializations);
        }

        // GET: Specializations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specializations specializations = await db.Specializations.FindAsync(id);
            if (specializations == null)
            {
                return HttpNotFound();
            }
            return View(specializations);
        }

        // POST: Specializations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Specializations specializations = await db.Specializations.FindAsync(id);
            db.Specializations.Remove(specializations);
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
