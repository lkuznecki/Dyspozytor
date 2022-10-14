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
    public class KierowcaController : Controller
    {
        private ZajezdniaContext db = new ZajezdniaContext();

        // GET: Kierowca
        public ActionResult Index()
        {
            return View(db.Kierowcy.ToList());
        }

        // GET: Kierowca/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierowca kierowca = db.Kierowcy.Find(id);
            if (kierowca == null)
            {
                return HttpNotFound();
            }
            return View(kierowca);
        }

        // GET: Kierowca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kierowca/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nazwisko,Imie,Rozpocz_Pracy")] Kierowca kierowca)
        {
            if (ModelState.IsValid)
            {
                db.Kierowcy.Add(kierowca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kierowca);
        }

        // GET: Kierowca/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierowca kierowca = db.Kierowcy.Find(id);
            if (kierowca == null)
            {
                return HttpNotFound();
            }
            return View(kierowca);
        }

        // POST: Kierowca/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nazwisko,Imie,Rozpocz_Pracy")] Kierowca kierowca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kierowca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kierowca);
        }

        // GET: Kierowca/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kierowca kierowca = db.Kierowcy.Find(id);
            if (kierowca == null)
            {
                return HttpNotFound();
            }
            return View(kierowca);
        }

        // POST: Kierowca/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kierowca kierowca = db.Kierowcy.Find(id);
            db.Kierowcy.Remove(kierowca);
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
