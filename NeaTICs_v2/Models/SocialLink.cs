using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class SocialLink
    {
        public int Id { get; set; }
        public SocialType Type { get; set; }
        public string Link { get; set; }
    }
}