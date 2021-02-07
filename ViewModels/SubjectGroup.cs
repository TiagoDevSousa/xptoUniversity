using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace xptoUniversity.ViewModels
{
    public class SubjectGroup
    {
        public string Subject { get; set; }
        public string TeachersName { get; set; }
        public int TeachersSalary { get; set; }
        public DateTime TeachersBirthday { get; set; }
        public int StudentsCount { get; set; }
        public List<decimal> Grades {
            get { return _grades; } 
            set { _grades = value; } 
        }
        private List<decimal> _grades;
    }
}