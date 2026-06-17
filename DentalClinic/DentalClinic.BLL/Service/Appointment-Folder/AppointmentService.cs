using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.ADL.DTOs.Response.Create;
using DentalClinic.ADL.DTOs.Response.Get;
using DentalClinic.ADL.Models;
using DentalClinic.ADL.Repository;
using Mapster;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Appointment_Folder
{
    public class AppointmentService :IAppointmentService
    {
        private readonly IGenericRepository<Patient> _patientRepo;
        private readonly IGenericRepository<Appointment> _appointmentRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppointmentService(IGenericRepository<Patient> PatientRepo,
            IGenericRepository<Appointment> AppointmentRepo,
            UserManager<ApplicationUser> userManager
            )
        {
            _patientRepo = PatientRepo;
            _appointmentRepo = AppointmentRepo;
            _userManager = userManager;
        }
        public async Task<CreateAppointmentResponse> CreateAppointmentAsync(CreateAppointmentRequest createAppointmentRequest)
        {
            //  check patient
            var patient = await _patientRepo.FindByIdAsync(createAppointmentRequest.PatientId);
            if (patient == null)
            {
                return new CreateAppointmentResponse { Success = false, Message = "PatientNotFound" };
            }
            // check doctor
            var doctor = await _userManager.FindByIdAsync(createAppointmentRequest.DoctorId);
            if (doctor is null) { return new CreateAppointmentResponse { Success = false, Message = "Doctor does not exist" }; }
            // check doctor role
            var isDoctore = await _userManager.IsInRoleAsync(doctor, "Doctor");
            if (!isDoctore) { return new CreateAppointmentResponse { Success = false, Message = "selected user is not a doctor" }; }
            
            //prevent take appointemt at the past date
            if(createAppointmentRequest.AppointmentTime< DateTime.UtcNow)
            {
                return new CreateAppointmentResponse
                {
                    Success = false,
                    Message = "AppointmentTimeMustBeFuture"
                     //Message = DateTime.UtcNow.ToString()
                };
            }

            //check clinic working houres
            var clinicStart = new TimeSpan(9, 0, 0);
            var clinicEnd = new TimeSpan(17, 0, 0);
            if(createAppointmentRequest.AppointmentTime.TimeOfDay <  clinicStart ||
                createAppointmentRequest.AppointmentTime.TimeOfDay > clinicEnd)
            { return new CreateAppointmentResponse { Success = false, Message = "ClinicClosed" }; }
           
               

            // check appointment time availability
            var isBooked = await _appointmentRepo.ExistsAsync(
                a => a.DoctorId == createAppointmentRequest.DoctorId &&
                a.AppointmentTime == createAppointmentRequest.AppointmentTime &&
                a.AppointmentStatus != AppointmentStatusEnum.Cancelled);
            if (isBooked)
            {
                return new CreateAppointmentResponse
                {
                    Success = false,
                    Message = "Doctor already has an appointment at this time"
                };
            }
            //  create appointment entity
            var appointmentData = createAppointmentRequest.Adapt<Appointment>();
            await _appointmentRepo.CreateAsync(appointmentData);
            // save
            await _appointmentRepo.SaveChangesAsync();
            //return
            return new CreateAppointmentResponse { Success = true, Message = " appointment was created successfully" };

        }
        //get all the appointment for the doctor
        public async Task<GetAppointmentResponseList> GetAppointmentAsyncForDoctor(string doctorId)
        {
            var doctor = await _userManager.FindByIdAsync(doctorId);

            if (doctor == null)
            {
                return new GetAppointmentResponseList
                {
                    Success = false,
                    Message = "DoctorNotFound"
                };
            }

            var isDoctor = await _userManager.IsInRoleAsync(doctor, "Doctor");

            if (!isDoctor)
            {
                return new GetAppointmentResponseList
                {
                    Success = false,
                    Message = "UserIsNotDoctor"
                };
            }

            var appointments = await _appointmentRepo.FindAllAsync(
                a => a.DoctorId == doctorId
            );
           
            return new GetAppointmentResponseList
            {
                Success = true,
                Message = "AppointmentsRetrieved",
                appointmentResponses = appointments.Adapt<List<GetAppointmentResponse>>()
            };
        }
    }
}
