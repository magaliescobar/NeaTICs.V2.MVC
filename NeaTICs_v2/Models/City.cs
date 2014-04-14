using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeaTICs_v2.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public Province ProvinceId { get; set; }
    }
}