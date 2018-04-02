using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Tribune
    {
        public int TribuneID { set; get; }
        public string Name { set; get; }
        public int FacultyID { set; get; }
        public Faculty Faculty { set; get; }
        public ICollection<Course> Courses { set; get; }
        public ICollection<Statement> Statements { set; get; }
        public Tribune()
        {
            this.Courses = new HashSet<Course>();
            this.Statements = new List<Statement>();
        }
    }
}