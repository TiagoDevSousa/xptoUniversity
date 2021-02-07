using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace xptoUniversity.ViewModels
{
    public class CoursesGroup
    {
        public string Course { get; set; }
        public int TeachersCount { get; set; }
        public int StudentsCount { get; set; }
        public decimal? AvgGrade { get; set; }
    }
}