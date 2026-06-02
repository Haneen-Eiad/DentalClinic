using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Response
{
    public class CreateAppointmentResponse : BaseResponse
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int PatientId { get; set; }
        public string DoctorId { get; set; }
        public AppointmentStatusEnum AppointmentStatus { get; set; }
     
    }
}
