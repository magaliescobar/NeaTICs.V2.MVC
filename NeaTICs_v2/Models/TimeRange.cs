using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class TimeRange
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}