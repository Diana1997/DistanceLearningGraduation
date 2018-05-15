using DistanceLearningGraduation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistanceLearningGraduation.Controllers
{
    public class TestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            //Question
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name");
            ViewBag.LessonID = new SelectList(db.Lessons, "LessonID", "Name");
            return View();
        }

        public ActionResult Create(Test test, string answer)
        {

            return View();
        }
    }
}