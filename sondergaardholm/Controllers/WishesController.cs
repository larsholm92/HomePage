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
    public class WishesController : Controller
    {
        private sondergaardholmContext db = new sondergaardholmContext();

        // GET: WishList
        public ActionResult Index()
        {
            return View(db.WishList.ToList());
        }

        // GET: Wishes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish wish = db.WishList.Find(id);
            if (wish == null)
            {
                return HttpNotFound();
            }
            return View(wish);
        }

        // GET: Wishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Link,Owner")] Wish wish)
        {
            if (ModelState.IsValid)
            {
                db.WishList.Add(wish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wish);
        }

        // GET: Wishes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish wish = db.WishList.Find(id);
            if (wish == null)
            {
                return HttpNotFound();
            }
            return View(wish);
        }

        // POST: Wishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Link,Owner")] Wish wish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wish);
        }

        // GET: Wishes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wish wish = db.WishList.Find(id);
            if (wish == null)
            {
                return HttpNotFound();
            }
            return View(wish);
        }

        // POST: Wishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wish wish = db.WishList.Find(id);
            db.WishList.Remove(wish);
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
