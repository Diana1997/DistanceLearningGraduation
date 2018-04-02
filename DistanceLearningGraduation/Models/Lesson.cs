using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Lesson
    {
        public int LessonID { get; set; }
        public string Name { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
        public ICollection<Lecture> Lectures { set; get; }
        public ICollection<Exam> Exams { set; get; }
        public ICollection<Question> Questions { set; get; }
        public Lesson()
        {
            this.Lectures = new List<Lecture>();
            this.Exams = new List<Exam>();
            this.Questions = new List<Question>();
        }
    } 
}