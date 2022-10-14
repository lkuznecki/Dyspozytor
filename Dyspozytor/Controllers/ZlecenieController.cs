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
    public class ZlecenieController : Controller
    {
        private ZajezdniaContext db = new ZajezdniaContext();

        // GET: Zlecenie
        public ActionResult Index()
        {
            var zlecenia = db.Zlecenia.Include(z => z.Kierowca).Include(z => z.Pojazd);
            return View(zlecenia.ToList());
        }

        // GET: Zlecenie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zlecenie zlecenie = db.Zlecenia.Find(id);
            if (zlecenie == null)
            {
                return HttpNotFound();
            }
            return View(zlecenie);
        }

        // GET: Zlecenie/Create
        public ActionResult Create()
        {
            ViewBag.KierowcaID = new SelectList(db.Kierowcy, "ID", "Nazwisko");
            ViewBag.PojazdID = new SelectList(db.Pojazdy, "PojazdID", "Nazwa_Pojazdu");
            return View();
        }

        // POST: Zlecenie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZlecenieID,PojazdID,KierowcaID,Godz_Rozp,Zleceniodawca,Godz_zakoncz,Wtrasie")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Zlecenia.Add(zlecenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KierowcaID = new SelectList(db.Kierowcy, "ID", "Nazwisko", zlecenie.KierowcaID);
            ViewBag.PojazdID = new SelectList(db.Pojazdy, "PojazdID", "Nazwa_Pojazdu", zlecenie.PojazdID);
            return View(zlecenie);
        }

        // GET: Zlecenie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zlecenie zlecenie = db.Zlecenia.Find(id);
            if (zlecenie == null)
            {
                return HttpNotFound();
            }
            ViewBag.KierowcaID = new SelectList(db.Kierowcy, "ID", "Nazwisko", zlecenie.KierowcaID);
            ViewBag.PojazdID = new SelectList(db.Pojazdy, "PojazdID", "Nazwa_Pojazdu", zlecenie.PojazdID);
            return View(zlecenie);
        }

        // POST: Zlecenie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZlecenieID,PojazdID,KierowcaID,Godz_Rozp,Zleceniodawca,Godz_zakoncz,Wtrasie")] Zlecenie zlecenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zlecenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KierowcaID = new SelectList(db.Kierowcy, "ID", "Nazwisko", zlecenie.KierowcaID);
            ViewBag.PojazdID = new SelectList(db.Pojazdy, "PojazdID", "Nazwa_Pojazdu", zlecenie.PojazdID);
            return View(zlecenie);
        }

        // GET: Zlecenie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zlecenie zlecenie = db.Zlecenia.Find(id);
            if (zlecenie == null)
            {
                return HttpNotFound();
            }
            return View(zlecenie);
        }

        // POST: Zlecenie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zlecenie zlecenie = db.Zlecenia.Find(id);
            db.Zlecenia.Remove(zlecenie);
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
