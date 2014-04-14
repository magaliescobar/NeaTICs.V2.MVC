using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Section> Sections { get; set; }
        public virtual IEnumerable<Person> People { get; set; }
    }
}