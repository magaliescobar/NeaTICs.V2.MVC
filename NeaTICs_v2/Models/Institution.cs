using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class Institution : Person
    {
        public string Detail { get; set; }
        public string About { get; set; }
        public List<Goal> Goals { get; set; }
        public List<Project> Projects { get; set; }
        public List<Experience> Experiences { get; set; }
        public string Type { get; set; }
    }
}