using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public virtual IEnumerable<City> Cities { get; set; }
    }
}