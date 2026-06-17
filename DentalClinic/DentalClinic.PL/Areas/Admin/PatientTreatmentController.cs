using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.BLL.Service.PatientTreatment_Folder;
using DentalClinic.PL.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DentalClinic.PL.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTreatmentController : ControllerBase
    {
        private readonly IPatientTreatmentService _patientTreatmentService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public PatientTreatmentController(IPatientTreatmentService patientTreatmentService
            ,IStringLocalizer<SharedResource> localizer
            )
        {
            _patientTreatmentService = patientTreatmentService;
            _localizer = localizer;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreatePatientTreatmentAsync([FromBody]CreatePatientTreatmentRequest request)
        {
            var response = await _patientTreatmentService.CreatePatientTreatmentAsync(request);
            if (!response.Success)
            {
                return BadRequest(new { message = _localizer["PatientTreatmentCantCreated"].Value, response });
            }
            return Ok(new {message = _localizer["PatientTreatmentCreatedSuccessfully"].Value,response});
        }
    }
}
