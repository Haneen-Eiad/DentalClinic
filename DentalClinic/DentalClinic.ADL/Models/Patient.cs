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
    public class Patient: BaseModel
    {
        [MaxLength(100,ErrorMessage ="Full Name Too long")]
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        [MaxLength(100,ErrorMessage = "Too long Text")]
        public string? City { get; set; }
        [MaxLength(100,ErrorMessage = "Too long Text")]
        public string? Street { get; set; }
        public GenderEnum? Gender { get; set; }
        [Phone(ErrorMessage ="Invalid Phone Number")]
        public string? EmergencyContactPhone { get; set; }
        [MaxLength(500,ErrorMessage ="Too long Text")]
        public string? MedicalNotes { get; set; }
        public string? BloodType { get; set; }
        [Range(0,double.MaxValue,ErrorMessage ="out of the range")]
        public decimal? Debt { get; set; }
        // relation with identity user -- 1 -1  relation 
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        // relation with Appointment
        public List<Appointment> Appointment { get; set; }
    }
}
