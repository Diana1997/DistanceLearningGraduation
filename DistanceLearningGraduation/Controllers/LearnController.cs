using DistanceLearningGraduation.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistanceLearningGraduation.Controllers
{
    public class LearnController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Learn
        public ActionResult Index(int? id)
        {
            var currentUserId = User.Identity.GetUserId();
            var CourseList = db.UserCourse.Where(x => x.UserID == currentUserId);
            var CourseID = CourseList.Count() > 0 ? CourseList.First().CourseID : 0;
            ViewBag.LessonList = db.Lessons.Where(x => x.CourseID == CourseID).ToList();
            ViewBag.LectureList = db.Lectures.Where(x => x.LessonID == id);
            return View();
        }

        public ActionResult Read(string path)
        {
            ViewBag.Path = path;
            return View();
        }
    }
}