using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class Informatorio : Institution
    {
        public List<InformatorioForm> Forms { get; set; }
        public List<Course> Courses { get; set; }
    }
}