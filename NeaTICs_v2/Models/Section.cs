using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public virtual IEnumerable<Profile> Profiles { get; set; }
    }
}