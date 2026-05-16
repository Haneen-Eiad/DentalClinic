using DentalClinic.ADL.DTOs.Request;
using DentalClinic.BLL.Service.TreatmentService_Folder;
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
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IStringLocalizer _localizer;

        public TreatmentsController(ITreatmentService treatmentService, IStringLocalizer<SharedResource> localizer)
        {
            _treatmentService = treatmentService;
            _localizer = localizer;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateTreatmentAsync([FromBody] CreateTreatmentRequest createTreatmentRequest)
        {
            var response = await _treatmentService.CreateTreatmentAsync(createTreatmentRequest);
            if (!response.Success)
            {
                return BadRequest(new { message = _localizer["TreatmentCantCreated"].Value,response});

            }
            return Ok(new {message = _localizer["TreatmentCreated"].Value, response});
        }
    }
}
