using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace xptoUniversity.Models
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Salary { get; set; }

        //public Subject subject { get; set; }
    }
}