using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sondergaardholm.Models;

namespace sondergaardholm.Controllers
{
    public class FuelingsController : Controller
    {
        private sondergaardholmContext db = new sondergaardholmContext();

        // GET: Fuelings
        public ActionResult Index()
        {
            return PartialView(db.Fuelings.ToList());
        }

        // GET: Fuelings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fueling fueling = db.Fuelings.Find(id);
            if (fueling == null)
            {
                return HttpNotFound();
            }
            return PartialView(fueling);
        }

        // GET: Fuelings/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Fuelings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Liters,Kilometers")] Fueling fueling)
        {
            fueling.Date = DateTime.Now.ToShortDateString();
            fueling.KilometersPerLiter = fueling.Kilometers / fueling.Liters;
            if (ModelState.IsValid)
            {
                db.Fuelings.Add(fueling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return PartialView(fueling);
        }

        // GET: Fuelings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fueling fueling = db.Fuelings.Find(id);
            if (fueling == null)
            {
                return HttpNotFound();
            }
            return PartialView(fueling);
        }

        // POST: Fuelings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Liters,Kilometers,Date")] Fueling fueling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fueling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return PartialView(fueling);
        }

        // GET: Fuelings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fueling fueling = db.Fuelings.Find(id);
            if (fueling == null)
            {
                return HttpNotFound();
            }
            return PartialView(fueling);
        }

        // POST: Fuelings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fueling fueling = db.Fuelings.Find(id);
            db.Fuelings.Remove(fueling);
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
