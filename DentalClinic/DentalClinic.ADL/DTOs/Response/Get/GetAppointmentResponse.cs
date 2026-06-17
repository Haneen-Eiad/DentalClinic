using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Response.Get
{
    public class GetAppointmentResponse 
    {
        public AppointmentTypeEnum AppointmentType { get; set; } = AppointmentTypeEnum.NewVisit;
        public DateTime AppointmentTime { get; set; } = DateTime.UtcNow;
    }
}
