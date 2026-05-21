using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public enum BloodTypeEnum
    {
        APositive,
        ANegative,
        BPositive,
        BNegative,
        OPositive,
        ONegative,
        ABPositive,
        ABNegative
    }
   
    public class Patient: BaseModel
    {

        [MaxLength(20)]
        [Required]
        public string PatientIdentificationCard { get; set; } 
        [MaxLength(100,ErrorMessage ="Full Name Too long")]
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        [MaxLength(50,ErrorMessage = "Too long Text")]
        public string? City { get; set; }
        [MaxLength(50,ErrorMessage = "Too long Text")]
        public string? Street { get; set; }
        public GenderEnum Gender { get; set; }
        [Phone]
        public string? EmergencyContactPhone { get; set; }
        [MaxLength(500,ErrorMessage ="Too long Text")]
        public string? MedicalNotes { get; set; }
        public BloodTypeEnum? BloodType { get; set; }
        [Range(0,double.MaxValue,ErrorMessage ="out of the range")]
        public decimal? Debt { get; set; }
        // relation with identity user -- 1 -1  relation 
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        // relation with Appointment
        public List<Appointment>? Appointments { get; set; }
    }
}
