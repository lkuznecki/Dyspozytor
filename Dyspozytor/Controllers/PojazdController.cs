using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dyspozytor.DAL;
using Dyspozytor.Models;

namespace Dyspozytor.Controllers
{
    public class PojazdController : Controller
    {
        private ZajezdniaContext db = new ZajezdniaContext();

        // GET: Pojazd
        public ActionResult Index()
        {
            return View(db.Pojazdy.ToList());
        }

        // GET: Pojazd/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pojazd pojazd = db.Pojazdy.Find(id);
            if (pojazd == null)
            {
                return HttpNotFound();
            }
            return View(pojazd);
        }

        // GET: Pojazd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pojazd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PojazdID,Nazwa_Pojazdu,Pojemnosc")] Pojazd pojazd)
        {
            if (ModelState.IsValid)
            {
                db.Pojazdy.Add(pojazd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pojazd);
        }

        // GET: Pojazd/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pojazd pojazd = db.Pojazdy.Find(id);
            if (pojazd == null)
            {
                return HttpNotFound();
            }
            return View(pojazd);
        }

        // POST: Pojazd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PojazdID,Nazwa_Pojazdu,Pojemnosc")] Pojazd pojazd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pojazd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pojazd);
        }

        // GET: Pojazd/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pojazd pojazd = db.Pojazdy.Find(id);
            if (pojazd == null)
            {
                return HttpNotFound();
            }
            return View(pojazd);
        }

        // POST: Pojazd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pojazd pojazd = db.Pojazdy.Find(id);
            db.Pojazdy.Remove(pojazd);
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
