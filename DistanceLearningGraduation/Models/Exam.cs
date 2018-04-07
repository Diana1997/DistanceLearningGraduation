using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Exam
    {
        public int ExamID { get; set; }
        public DateTime Day { get; set; }
        public string Time { get; set; }
        public int LessonID { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public Lesson Lesson { get; set; }
    }
}