using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeaTICs_v2.Models
{
    public class InformatorioForm
    {
        public int Id { get; set; }

        public string Reasons { get; set; }
        public string Preferences { get; set; }
        public string Trainings { get; set; }
        public string Expectations { get; set; }
        public TimeAvailability TimeAvailabilty { get; set; }
        public string strTimeAvailabilty { get; set; } //Agregado para usar solo el textbox

        public DateTime FechaInscripcion { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public Users User { get; set; }
    }
}