using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public class PatientTreatment :  BaseModel
    {
        [MaxLength(500,ErrorMessage ="Too long text")]
        public string? PatientTreatmentNote { get; set; }
        //relation with Treatment
        public string? TreatmentId { get; set; }
        public Treatment? Treatment { get; set; }

        //relation with user
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        
        //relation with patient table 
        public string? PatientId { get; set; }
        public Patient? Patient { get; set; }

        //realation with Appointment table 
        public string? AppointmentId { get; set; }
        public Appointment? Appointment  { get; set; }

    }
}
