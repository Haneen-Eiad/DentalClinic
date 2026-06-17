using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.BLL.Service.PrescriptionService_Folder;
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
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public PrescriptionController(IPrescriptionService prescriptionService
            , IStringLocalizer<SharedResource> localizer
            )
        {
            _prescriptionService = prescriptionService;
            _localizer = localizer;
        }

        [HttpPost("")]

        public async Task<IActionResult> createPrescriptionAsync([FromBody]CreatePrescriptionRequest prescriptionRequest)
        {
            var response = await _prescriptionService.CreatePrescriptionAsync(prescriptionRequest);
            if (!response.Success) { return BadRequest(new { message = _localizer["PrescriptionCantCreated"].Value, response }); }
            ;

            return Ok(new { message = _localizer["PrescriptionCreated"].Value, response });

        }
    }
}
