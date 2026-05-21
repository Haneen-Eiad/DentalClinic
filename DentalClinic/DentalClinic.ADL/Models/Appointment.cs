using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public enum AppointmentTypeEnum
    {
        NewVisit = 0,
        Revision = 1,
        TreatmentSession = 2,
        Emergency = 3
    }
    public class Appointment : BaseModel {

        [Required]
        public DateTime AppointmentTime { get; set; }
        public AppointmentStatusEnum AppointmentStatus { get; set; } = AppointmentStatusEnum.Scheduled;
        public DateTime? ArrivalTime { get; set; }
        public decimal? ReservationFee { get; set; }
        [Required]
        public AppointmentTypeEnum appointmentType { get; set; } = AppointmentTypeEnum.NewVisit;
        public int? QueueNumber { get; set; }
        public List<AppointmentNote>? AppointmentNotes { get; set; }

        //relation with patient table
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        //relation with users table
        public string DoctorId { get; set; }
        public ApplicationUser Doctor { get; set; }

        //relation with payment ...its not list cause i made the fees for reservation fixed amount which is 20 shekels 
       public Payment? payment { get; set; }

    }
}
