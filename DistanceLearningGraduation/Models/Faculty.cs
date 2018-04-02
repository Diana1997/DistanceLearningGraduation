using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Faculty
    {
        public int FacultyID { set; get; }
        public String Name { get; set; }
        public ICollection<Tribune> Tribunes { set; get; }
        public ICollection<Statement> Statements { set; get; }
        public Faculty()
        {
            this.Tribunes = new HashSet<Tribune>();
            this.Statements = new List<Statement>();
        }
    }
}