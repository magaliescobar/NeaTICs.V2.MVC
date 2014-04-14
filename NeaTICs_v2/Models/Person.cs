using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NeaTICs_v2.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CUIL_CUIT { get; set; }
        public DateTime FechaNac { get; set; }

        public Address Address { get; set; }
        public List<Telephone> Telephone { get; set; }
        public List<SocialLink> SocialLinks { get; set; }
        public string Email { get; set; }

        public Profile Profile { get; set; }
    }
}