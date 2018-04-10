using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistanceLearningGraduation.Models
{
    public class Statement
    {
        public string UserID { set; get; }
        public int StatementID { set; get; }
        public string Firstname { set; get; }
        public string Secondname { set; get; }
        public string Lastname { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public DateTime Birthday { set; get; }
        public string Email { set; get; }
        public bool Confirm { set; get; }
        public int FacultyID { set; get; }
        public int TribuneID { set; get; }
        public int CourseID { set; get; }
        public Faculty Faculty { set; get; }
        public Tribune Tribune { set; get; }
        public Course Course { set; get; }
    }
}