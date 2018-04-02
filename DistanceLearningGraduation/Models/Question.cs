using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Question
    {
        public int QuestionID { set; get; }
        public string QuestionText { set; get; }
        public int CourseID { set; get; }
        public int LessonID { set; get; }

        public Course Course { set; get; }
        public Lesson Lesson { set; get; }
        public int UserID { set; get; }
        public ICollection<Answer> Answers { set; get; }
        public Question()
        {
            this.Answers = new List<Answer>();
        }
    }
}