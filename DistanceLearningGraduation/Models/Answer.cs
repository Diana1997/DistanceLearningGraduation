using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Answer
    {
        public int AnswerID { set; get; }
        public string AnswerText { set; get; }
        public bool IsRight { set; get; }
        public int QuestionID { set; get; }
        public Question Question { set; get; }
    }
}