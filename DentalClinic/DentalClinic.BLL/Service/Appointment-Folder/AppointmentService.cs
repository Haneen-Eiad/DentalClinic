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
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.BLL.Service.Appointment_Folder
{
    public class AppointmentService :IAppointmentService
    {
        private readonly IGenericRepository<Patient> _patientRepo;
        private readonly IGenericRepository<Appointment> _appointmentRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAppointmentQueueService _queueService;

        public AppointmentService(IGenericRepository<Patient> PatientRepo,
            IGenericRepository<Appointment> AppointmentRepo,
            UserManager<ApplicationUser> userManager,
             IAppointmentQueueService queueService

            )
        {
            _patientRepo = PatientRepo;
            _appointmentRepo = AppointmentRepo;
            _userManager = userManager;
            _queueService = queueService;
        }
        public async Task<CreateAppointmentResponse> CreateAppointmentAsync(CreateAppointmentRequest createAppointmentRequest)
        {
            // 1. check patient
            var patient = await _patientRepo.FindByIdAsync(createAppointmentRequest.PatientId);
            if (patient == null)
            {
                return new CreateAppointmentResponse
                {
                    Success = false,
                    Message = "PatientNotFound"
                };
            }

            // 2. check doctor
            var doctor = await _userManager.FindByIdAsync(createAppointmentRequest.DoctorId);
            if (doctor is null)
            {
                return new CreateAppointmentResponse
                {
                    Success = false,
                    Message = "DoctorDoesNotExist"
                };
            }

            // 3. check doctor role
            var isDoctor = await _userManager.IsInRoleAsync(doctor, "Doctor");
            if (!isDoctor)
            {
                return new CreateAppointmentResponse
                {
                    Success = false,
                    Message = "UserIsNotDoctor"
                };
            }

            // 4. prevent past time
            if (createAppointmentRequest.AppointmentTime < DateTime.UtcNow)
            {
                return new CreateAppointmentResponse
                {
                    Success = false,
                    Message = "AppointmentTimeMustBeFuture"
                };
            }

            // 5. clinic working hours
            var clinicStart = new TimeSpan(9, 0, 0);
            var clinicEnd = new TimeSpan(17, 0, 0);

            if (createAppointmentRequest.AppointmentTime.TimeOfDay < clinicStart ||
                createAppointmentRequest.AppointmentTime.TimeOfDay > clinicEnd)
            {
                return new CreateAppointmentResponse
                {
                    Success = false,
                    Message = "ClinicClosed"
                };
            }

            // ======================================================
            // 🔥 NEW: HANDLE LATE APPOINTMENTS BEFORE NEW BOOKING
            // ======================================================

            var doctorAppointments = await _appointmentRepo.FindAllAsync(
                a => a.DoctorId == createAppointmentRequest.DoctorId &&
                     a.AppointmentStatus == AppointmentStatusEnum.Scheduled
            );

            foreach (var appointment in doctorAppointments)
            {
                var diffMinutes = (DateTime.UtcNow - appointment.AppointmentTime).TotalMinutes;

                if (diffMinutes > 10)
                {
                    await _queueService.HandleLateAppointmentAsync(
             appointment.Id
         );
                }
            }

            

            // 6. check duplicate booking
            var isBooked = await _appointmentRepo.ExistsAsync(
    a => a.DoctorId == createAppointmentRequest.DoctorId &&
         a.AppointmentTime == createAppointmentRequest.AppointmentTime &&
         a.AppointmentStatus == AppointmentStatusEnum.Scheduled
);

            if (isBooked)
            {
                return new CreateAppointmentResponse
                {
                    Success = false,
                    Message = "DoctorAlreadyHasAppointmentAtThisTime"
                };
            }

            // 7. create appointment
            var appointmentData = createAppointmentRequest.Adapt<Appointment>();

            await _appointmentRepo.CreateAsync(appointmentData);
            await _appointmentRepo.SaveChangesAsync();

            await _queueService.RebuildQueueAsync(
            appointmentData.DoctorId,
            appointmentData.AppointmentTime.Date
);

            return new CreateAppointmentResponse
            {
                Success = true,
                Message = "AppointmentCreatedSuccessfully"
            };
        }

        public async Task<ChangeAppointmentStatusResponse> ChangeAppointmentStatusAsync(
     int appointmentId,
     AppointmentStatusEnum status)
        {
            var appointment = await _appointmentRepo.FindByIdAsync(appointmentId);

            if (appointment == null)
            {
                return new ChangeAppointmentStatusResponse
                {
                    Success = false,
                    Message = "AppointmentNotFound"
                };
            }

            // لا نسمح بتعديل الموعد المنتهي أو الملغي
            if (appointment.AppointmentStatus == AppointmentStatusEnum.Finished ||
                appointment.AppointmentStatus == AppointmentStatusEnum.Cancelled)
            {
                return new ChangeAppointmentStatusResponse
                {
                    Success = false,
                    Message = "CannotChangeFinishedOrCancelledAppointment"
                };
            }

            var currentStatus = appointment.AppointmentStatus;

            // Scheduled -> Arrived / Cancelled / Late فقط
            if (currentStatus == AppointmentStatusEnum.Scheduled &&
                status != AppointmentStatusEnum.Arrived &&
                status != AppointmentStatusEnum.Cancelled &&
                status != AppointmentStatusEnum.Late)
            {
                return new ChangeAppointmentStatusResponse
                {
                    Success = false,
                    Message = "InvalidStatusTransition"
                };
            }

            // Arrived -> InTreatment / Cancelled فقط
            if (currentStatus == AppointmentStatusEnum.Arrived &&
                status != AppointmentStatusEnum.InTreatment &&
                status != AppointmentStatusEnum.Cancelled)
            {
                return new ChangeAppointmentStatusResponse
                {
                    Success = false,
                    Message = "InvalidStatusTransition"
                };
            }

            // InTreatment -> Finished فقط
            if (currentStatus == AppointmentStatusEnum.InTreatment &&
                status != AppointmentStatusEnum.Finished)
            {
                return new ChangeAppointmentStatusResponse
                {
                    Success = false,
                    Message = "InvalidStatusTransition"
                };
            }

            // تسجيل وقت الوصول
            if (status == AppointmentStatusEnum.Arrived)
            {
                appointment.ArrivalTime = DateTime.UtcNow;
            }

            appointment.AppointmentStatus = status;

            // إعادة ترتيب الطابور عند خروج الموعد منه
            if (status == AppointmentStatusEnum.Cancelled ||
                status == AppointmentStatusEnum.Finished ||
                status == AppointmentStatusEnum.Late)
            {
                appointment.QueueNumber = null;

                await _queueService.RebuildQueueAsync(
                    appointment.DoctorId,
                    appointment.AppointmentTime.Date
                );
            }

            await _appointmentRepo.SaveChangesAsync();

            return new ChangeAppointmentStatusResponse
            {
                Success = true,
                Message = "StatusUpdatedSuccessfully"
            };
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

        //get all appointment for patient himself
        public async Task<GetAppointmentResponseList> GetAppointmentsForPatientAsync(string doctorId, int patientId)
        {
            // Check doctor exists
            var doctor = await _userManager.FindByIdAsync(doctorId);

            if (doctor == null)
            {
                return new GetAppointmentResponseList
                {
                    Success = false,
                    Message = "DoctorNotFound"
                };
            }

            // Check role
            var isDoctor = await _userManager.IsInRoleAsync(doctor, "Doctor");

            if (!isDoctor)
            {
                return new GetAppointmentResponseList
                {
                    Success = false,
                    Message = "UserIsNotDoctor"
                };
            }

            // Check patient exists
            var patient = await _patientRepo.FindByIdAsync(patientId);

            if (patient == null)
            {
                return new GetAppointmentResponseList
                {
                    Success = false,
                    Message = "PatientNotFound"
                };
            }

            // Get patient's appointments
            var appointments = await _appointmentRepo.FindAllAsync(
                a => a.PatientId == patientId
            );

            return new GetAppointmentResponseList
            {
                Success = true,
                Message = "AppointmentsRetrieved",
                appointmentResponses =
                    appointments.Adapt<List<GetAppointmentResponse>>()
            };
        }
    }
}
