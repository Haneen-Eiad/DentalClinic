using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.Models
{
    public enum AppointmentStatusEnum
    {
        Scheduled = 0,
        Arrived = 1,
        InTreatment = 2,
        Finished = 3,
        Cancelled = 4,
        Late = 5
    }
    public class Appointment : BaseModel { 
      


       public List<AppointmentTranslation> appointmentTranslations { get; set; } 
        public DateTime? AppointmentTime { get; set; }
        public AppointmentStatusEnum AppointmentStatus { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public decimal ReservationFee { get; set; } 
        public int QueueNumber { get; set; }

        //relation with patient table
        public string? PatientId { get; set; }
        public Patient? Patient { get; set; }

        //relation with users table
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }

        //relation with payment ...should i keep it ? 
       public List<Payment>? payments { get; set; }

       
         
         





   
    }
}
