using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class TimeAvailability
    {
        public int Id { get; set; }
        public virtual IEnumerable<TimeRange> Time { get; set; }
    }
}