using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreatePrescriptionRequest
    {
        public string? PrescriptionNote { get; set; }
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public List<CreatePrescriptionItemRequest> PrescriptionItems { get; set; }
    }
}
