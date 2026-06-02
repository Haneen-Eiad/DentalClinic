using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
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
                return new CreateAppointmentResponse { Success = false, Message = "Patient is not registered" };
            }
            // check doctor
            var doctor = await _userManager.FindByIdAsync(createAppointmentRequest.DoctorId);
            if (doctor is null) { return new CreateAppointmentResponse { Success = false, Message = "Doctor does not exist" }; }
            // check doctor role
            var isDoctore = await _userManager.IsInRoleAsync(doctor, "Doctor");
            if (!isDoctore) { return new CreateAppointmentResponse { Success = false, Message = "selected user is not a doctor" }; }
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
    }
}
