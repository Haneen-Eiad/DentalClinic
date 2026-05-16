using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreatePatientTreatmentRequest
    {
        public string? PatientTreatmentNote { get; set; }
        public int? TreatmentId { get; set; }
        public string? UserId { get; set; }
        public int PatientId { get; set; }
        public int? AppointmentId { get; set; }
    }
}
