using DentalClinic.BLL.Service.Appointment_Folder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DentalClinic.PL.Areas.User
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "Doctor")]
    public class PatientAppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public PatientAppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPatientAppointments([FromRoute] int patientId)
        {
            var doctorId =
                User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response =
                await _appointmentService.GetAppointmentsForPatientAsync(
                    doctorId,
                    patientId);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }


    }
}
