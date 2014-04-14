using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Year { get; set; }

        public IEnumerable<Users> Students { get; set; }
    }
}