using System.Security.Claims;
using DentalClinic.ADL.DTOs.Request.Create;
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

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var currentDoctor = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _appointmentService.GetAppointmentAsyncForDoctor(currentDoctor);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
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

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> ChangeStatus(int id,[FromBody] ChangeAppointmentStatusRequest request)
        {
            var response = await _appointmentService.ChangeAppointmentStatusAsync( id,request.Status);

            if (!response.Success)
                return BadRequest(new
                {
                    message = response.Message
                });

            return Ok(new
            {
                message = response.Message
            });
        }
    }
}
