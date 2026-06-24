using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Appointment_Folder
{
    public interface IAppointmentQueueService
    {
        Task MarkAppointmentAsLateAsync(int appointmentId);
        Task<bool> IsAppointmentLateAsync(int appointmentId);
        Task HandleLateAppointmentAsync(int appointmentId);
        Task RebuildQueueAsync(string doctorId, DateTime date);
    }
}
