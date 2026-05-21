using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreatePatientRequest
    {
        [Required]
        [MaxLength(100,ErrorMessage ="Full Name too long")]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20,ErrorMessage = "Patient Identification Card number too long ")]
      
        public string PatientIdentificationCard { get; set; } =string.Empty;
        [Required]
        public DateTime BirthDate { get; set; }
        [MaxLength(50,ErrorMessage = "City Name too long")]
        public string? City { get; set; }
        [MaxLength(50, ErrorMessage = "street Name too long")]
        public string? Street { get; set; }
        public GenderEnum Gender { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Phone number too long")]
      
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string EmergencyContactPhone { get; set; } = string.Empty;
        [MaxLength(500,ErrorMessage = "Medical Notes too long")]
        public string? MedicalNotes { get; set; }
        //select options at FE
        public BloodTypeEnum? BloodType { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "out of the range")]
        public decimal? Debt { get; set; }

    }
}
