using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DistanceLearningGraduation.Models;

namespace DistanceLearningGraduation.Controllers
{
    public class TribunesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tribunes
        public ActionResult Index()
        {
            var tribunes = db.Tribunes.Include(t => t.Faculty);
            return View(tribunes.ToList());
        }

        // GET: Tribunes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tribune tribune = db.Tribunes.Find(id);
            if (tribune == null)
            {
                return HttpNotFound();
            }
            return View(tribune);
        }

        // GET: Tribunes/Create
        public ActionResult Create()
        {
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "Name");
            return View();
        }

        // POST: Tribunes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TribuneID,Name,FacultyID")] Tribune tribune)
        {
            if (ModelState.IsValid)
            {
                db.Tribunes.Add(tribune);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "Name", tribune.FacultyID);
            return View(tribune);
        }

        // GET: Tribunes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tribune tribune = db.Tribunes.Find(id);
            if (tribune == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "Name", tribune.FacultyID);
            return View(tribune);
        }

        // POST: Tribunes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TribuneID,Name,FacultyID")] Tribune tribune)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tribune).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "Name", tribune.FacultyID);
            return View(tribune);
        }

        // GET: Tribunes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tribune tribune = db.Tribunes.Find(id);
            if (tribune == null)
            {
                return HttpNotFound();
            }
            return View(tribune);
        }

        // POST: Tribunes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tribune tribune = db.Tribunes.Find(id);
            db.Tribunes.Remove(tribune);
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
