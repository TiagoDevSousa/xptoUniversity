using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace xptoUniversity.ViewModels
{
    public class BirthdayGroup
    {
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        public int StudentCount { get; set; }
    }
}