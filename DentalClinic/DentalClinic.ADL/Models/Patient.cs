using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DentalClinic.ADL.Models
{
    public enum GenderEnum
    {
        Male = 0,
        Female = 1
    }
    public class Patient: BaseModel
    {
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public GenderEnum? Gender { get; set; } 
        public string? EmergencyContactPhone { get; set; }
        public string? MedicalNotes { get; set; }
        public string? BloodType { get; set; } 
        public decimal? Debt { get; set; }
        // relation with identity user -- 1 -1  relation 
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        // relation with Appointment
        public List<Appointment> Appointment { get; set; }
    }
}
