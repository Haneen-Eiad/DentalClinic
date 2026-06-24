using DentalClinic.ADL.Models;
using DentalClinic.ADL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Appointment_Folder
{
    public class AppointmentQueueService : IAppointmentQueueService
    {
        private readonly IGenericRepository<Appointment> _appointmentRepo;

        public AppointmentQueueService(IGenericRepository<Appointment> AppointmentRepo)
        {
            _appointmentRepo = AppointmentRepo;
        }

        public async Task MarkAppointmentAsLateAsync(int appointmentId)
        {
            var appointment = await _appointmentRepo.FindByIdAsync(appointmentId);
            if (appointment == null)
                return;
            // إذا الموعد أصلاً ملغي أو منتهي لا نعمل شيء
            if (appointment.AppointmentStatus == AppointmentStatusEnum.Cancelled ||
                appointment.AppointmentStatus == AppointmentStatusEnum.Finished)
                return;
            // تغيير الحالة إلى Late
            appointment.AppointmentStatus = AppointmentStatusEnum.Late;
            await _appointmentRepo.SaveChangesAsync();
        }
        public async Task<bool> IsAppointmentLateAsync(int appointmentId)
        {
            var appointment = await _appointmentRepo.FindByIdAsync(appointmentId);

            if (appointment == null)
                return false;

            // إذا الموعد ملغي أو منتهي لا يعتبر late
            if (appointment.AppointmentStatus == AppointmentStatusEnum.Cancelled ||
                appointment.AppointmentStatus == AppointmentStatusEnum.Finished)
                return false;

            var now = DateTime.UtcNow;

            // فرق الوقت بين الموعد والآن
            var diffMinutes = (now - appointment.AppointmentTime).TotalMinutes;

            // هنا نحدد متى نعتبره "Late"
            if (diffMinutes > 10)   // 10 دقائق تأخير (يمكن تغييره لاحقاً)
                return true;

            return false;
        }

        public async Task HandleLateAppointmentAsync(int appointmentId)
        {
            var appointment = await _appointmentRepo.FindByIdAsync(appointmentId);

            if (appointment == null)
                return;

            if (appointment.AppointmentStatus == AppointmentStatusEnum.Cancelled ||
     appointment.AppointmentStatus == AppointmentStatusEnum.Finished ||
     appointment.AppointmentStatus == AppointmentStatusEnum.Late)
            {
                return;
            }

            appointment.AppointmentStatus = AppointmentStatusEnum.Late;
            appointment.QueueNumber = null;
            await _appointmentRepo.SaveChangesAsync();

                        await RebuildQueueAsync(
            appointment.DoctorId,
            appointment.AppointmentTime.Date
            );


//            var todayAppointments = await _appointmentRepo.FindAllAsync(
//    a => a.DoctorId == appointment.DoctorId &&
//         a.AppointmentTime.Date == appointment.AppointmentTime.Date &&
//         a.AppointmentStatus == AppointmentStatusEnum.Scheduled
//);


//            int queue = 1;

//            foreach (var item in todayAppointments.OrderBy(a => a.AppointmentTime))
//            {
//                item.QueueNumber = queue;
//                queue++;
//            }

//            await _appointmentRepo.SaveChangesAsync();


        }

        public async Task RebuildQueueAsync(string doctorId, DateTime date)
        {
            var appointments = await _appointmentRepo.FindAllAsync(
          a => a.DoctorId == doctorId &&
         a.AppointmentTime.Date == date.Date &&
         a.AppointmentStatus == AppointmentStatusEnum.Scheduled
          );

            int queue = 1;

            foreach (var appt in appointments.OrderBy(a => a.AppointmentTime))
            {
                appt.QueueNumber = queue;
                queue++;
            }

            await _appointmentRepo.SaveChangesAsync();
        }
    }


        }

