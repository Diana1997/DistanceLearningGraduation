using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Lecture
    {
        public int LectureID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Links { get; set; }
        public int LessonID { get; set; }
        public int CourseID { set; get; }
        public Lesson Lesson { get; set; }
        public Course Course { set; get; }
        
    }
}