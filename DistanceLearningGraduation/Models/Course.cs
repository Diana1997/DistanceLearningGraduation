using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public int TribuneID { get; set; }
        public Tribune Tribune { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Statement> Statements { set; get; }
        public ICollection<Exam> Exams { set; get; }
        public ICollection<Question> Questions { set; get; }
        public ICollection<Lecture> Lectures { set; get; }
        public Course()
        {
            this.Lessons = new HashSet<Lesson>();
            this.Statements = new List<Statement>();
            this.Exams = new List<Exam>();
            this.Questions = new List<Question>();
            this.Lectures = new List<Lecture>();
        }
    }
}