using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.ADL.DTOs.Response.Get
{
    public class GetAppointmentResponseList : BaseResponse
    {
        public List<GetAppointmentResponse> appointmentResponses { get; set; }
    }
}
