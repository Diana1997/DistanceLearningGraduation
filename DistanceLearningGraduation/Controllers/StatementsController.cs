using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DistanceLearningGraduation.Models;
using Microsoft.AspNet.Identity;

namespace DistanceLearningGraduation.Controllers
{
    public class StatementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Statements
        public ActionResult Index()
        {
            var statements = db.Statements.Include(s => s.Course).Include(s => s.Faculty).Include(s => s.Tribune);
            return View(statements.ToList());
        }

        // GET: Statements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statement statement = db.Statements.Find(id);
            if (statement == null)
            {
                return HttpNotFound();
            }
            return View(statement);
        }

        // GET: Statements/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name");
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "Name");
            ViewBag.TribuneID = new SelectList(db.Tribunes, "TribuneID", "Name");
            return View();
        }

        // POST: Statements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Statement statement)
        {
            if (ModelState.IsValid)
            {
                string currentUserID = User.Identity.GetUserId();
                db.Statements.Add(new Statement() {
                    UserID = currentUserID,
                    StatementID = statement.StatementID,
                    Firstname = statement.Firstname,
                    Secondname = statement.Secondname,
                    Lastname = statement.Lastname,
                    Address = statement.Address,
                    Phone = statement.Phone,
                    Birthday = statement.Birthday,
                    Email =statement.Email,
                    Confirm = false,
                    FacultyID = statement.FacultyID,
                    TribuneID = statement.TribuneID,
                    CourseID = statement.CourseID,
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name", statement.CourseID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "Name", statement.FacultyID);
            ViewBag.TribuneID = new SelectList(db.Tribunes, "TribuneID", "Name", statement.TribuneID);
            return View(statement);
        }

        // GET: Statements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statement statement = db.Statements.Find(id);
            if (statement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name", statement.CourseID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "Name", statement.FacultyID);
            ViewBag.TribuneID = new SelectList(db.Tribunes, "TribuneID", "Name", statement.TribuneID);
            return View(statement);
        }

        // POST: Statements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Statement statement)
        {
            if (ModelState.IsValid)
            {
                string currentUserID = User.Identity.GetUserId();
                db.Entry(new Statement()
                {
                    UserID = currentUserID,
                    StatementID = statement.StatementID,
                    Firstname = statement.Firstname,
                    Secondname = statement.Secondname,
                    Lastname = statement.Lastname,
                    Address = statement.Address,
                    Phone = statement.Phone,
                    Birthday = statement.Birthday,
                    Email = statement.Email,
                    Confirm = true,
                    FacultyID = statement.FacultyID,
                    TribuneID = statement.TribuneID,
                    CourseID = statement.CourseID,
                }).State = EntityState.Modified;
                db.UserCourse.Add(new UserCourse()
                {
                    UserID = currentUserID,
                    CourseID = statement.CourseID,
                });
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name", statement.CourseID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "Name", statement.FacultyID);
            ViewBag.TribuneID = new SelectList(db.Tribunes, "TribuneID", "Name", statement.TribuneID);
            return View(statement);
        }

        // GET: Statements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Statement statement = db.Statements.Find(id);
            if (statement == null)
            {
                return HttpNotFound();
            }
            return View(statement);
        }

        // POST: Statements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Statement statement = db.Statements.Find(id);
            db.Statements.Remove(statement);
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
