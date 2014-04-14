using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeaTICs_v2.Models
{
    public class Address
    {
        [Key]
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        [Column("StreetAddress")]
        public string StreetAddress { get; set; }

        [Column("ActualCity")]
        public City City { get; set; }

        public Person Person { get; set; }
        //[Column("ActualProvince")]
        //public string ProvinceId { get; set; }
    }
}