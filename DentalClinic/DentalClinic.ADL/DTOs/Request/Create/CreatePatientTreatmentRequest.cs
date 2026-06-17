using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request.Create
{
    public class CreatePatientTreatmentRequest
    {
        [MaxLength(500, ErrorMessage = "Too long text")]
        public string? PatientTreatmentNote { get; set; }
        [Required]
        public int TreatmentId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "cost must valid value")]
        public decimal Cost { get; set; }
        [Required]
        public int AppointmentId { get; set; }
    }
}
