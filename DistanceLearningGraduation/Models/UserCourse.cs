using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class UserCourse
    {
        public int UserCourseID { get; set; }
        public string UserID { get; set; }
        public int CourseID { get; set; }
    }
}