using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request.Create
{
    public class CreateAppointmentNoteRequest
    {
        [Required]
        [MaxLength(1000,ErrorMessage = "Appointment Note out of range")]
        public string Note { get; set; } = string.Empty;
    }
}
