using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeaTICs_v2.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public string ExperienceDescription { get; set; }

        public Users User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}