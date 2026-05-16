using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreatePatientRequest
    {
        public string? FullName { get; set; }
        public string PatientIdentificationCard { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public GenderEnum? Gender { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? MedicalNotes { get; set; }
        public string? BloodType { get; set; }
        public decimal? Debt { get; set; }

    }
}
