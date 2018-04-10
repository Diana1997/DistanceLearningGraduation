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
        public ActionResult Index()
        {
            var currentUserId = User.Identity.GetUserId();
            var CourseID = db.UserCourse.Where(x => x.UserID == currentUserId).First().CourseID;
            ViewBag.LessonList = db.Lessons.Where(x => x.CourseID == CourseID).ToList();
            return View();
        }
    }
}