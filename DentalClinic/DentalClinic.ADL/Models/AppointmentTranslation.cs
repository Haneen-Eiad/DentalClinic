using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class AppointmentTranslation
    {
        
        public int Id { get; set; }
        [MaxLength(500,ErrorMessage ="Too long text")]
        public string? AppointmentNotes { get; set; }
        public string? Language { get; set; } = "en";

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
    }
}
