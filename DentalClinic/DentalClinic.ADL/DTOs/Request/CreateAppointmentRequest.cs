using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request
{
    public class CreateAppointmentRequest
    {
        [Required]
        public DateTime AppointmentTime { get; set; } = DateTime.UtcNow;
        [Required]
        public AppointmentTypeEnum AppointmentType { get; set; } = AppointmentTypeEnum.NewVisit;
        public int PatientId { get; set; }
        public string DoctorId { get; set; }



    }
}
