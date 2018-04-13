using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Test
    {
        public Question Question { set; get; }
        public IList<Answer> Answers { set; get; }
    }
}