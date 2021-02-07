using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace xptoUniversity.ViewModels
{
    public class StudentSubjectGroup
    {
        public string Subject { get; set; }
        public List<StudendtsGrades> StudendtsGrades { get; set; }
    }

    public class StudendtsGrades
    {
        public string StudentName { get; set; }
        public decimal Grade { get; set; }
    }
}