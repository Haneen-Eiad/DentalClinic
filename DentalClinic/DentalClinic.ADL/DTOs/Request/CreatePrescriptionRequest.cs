using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreatePrescriptionRequest
    {
        public string? PrescriptionNote { get; set; }
        public int? AppointmentId { get; set; }
        public int PatientId { get; set; }
        public List<CreatePrescriptionItemRequest>PrescriptionItems { get; set; }
    }
}
