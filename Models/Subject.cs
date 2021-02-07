using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace xptoUniversity.Models
{
    public class Subject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubjectID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}