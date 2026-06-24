using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Request.Create
{
    public class ChangeAppointmentStatusRequest
    {
        public AppointmentStatusEnum Status { get; set; }
    }
}
