using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.ADL.DTOs.Response.Create;
using DentalClinic.ADL.DTOs.Response.Get;
using DentalClinic.ADL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Appointment_Folder
{
    public interface IAppointmentService
    {
        Task<CreateAppointmentResponse> CreateAppointmentAsync(CreateAppointmentRequest createAppointmentRequest);
        Task<GetAppointmentResponseList> GetAppointmentAsyncForDoctor(string doctorId);
        Task<GetAppointmentResponseList> GetAppointmentsForPatientAsync(string doctorId, int patientId);
        Task<ChangeAppointmentStatusResponse> ChangeAppointmentStatusAsync(int appointmentId, AppointmentStatusEnum status);
    };
}
