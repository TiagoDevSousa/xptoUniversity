using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xptoUniversity.Models
{
  
    public class Component
    {
        public int ComponentID { get; set; }
        public int CourseID { get; set; }
        public int SubjectID { get; set; }

        public virtual Course Course { get; set; }
        public virtual Subject Subject { get; set; }
    }
}