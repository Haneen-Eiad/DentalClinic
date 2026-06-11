using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
using DentalClinic.BLL.Service.Appointment_Folder;
using DentalClinic.PL.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DentalClinic.PL.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public AppointmentsController(IAppointmentService appointmentService,
            IStringLocalizer<SharedResource> localizer
            
            )
        {
            _appointmentService = appointmentService;
            _localizer = localizer;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateAppointmentAsync([FromBody] CreateAppointmentRequest request)
        {
            var response = await _appointmentService.CreateAppointmentAsync(request);
            if(!response.Success)
            {
                return BadRequest(new { message = _localizer["AppointmentCan'tCreated"].Value, Details = _localizer[response.Message].Value });

            }
            return Ok(new { message = _localizer["AppointmentCreated"].Value, Details = _localizer[response.Message].Value});

        }
    }
}
