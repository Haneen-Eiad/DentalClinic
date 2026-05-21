using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class AppointmentNote : BaseModel
    {
        public string Note { get; set; } = string.Empty;

        public int? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }

    }
}
