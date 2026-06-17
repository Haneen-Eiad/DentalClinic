using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.BLL.Service;
using DentalClinic.BLL.Service.PateintService_Folder;
using DentalClinic.PL.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DentalClinic.PL.Areas.Admin
{
    [Route("api/patients/[controller]")]
    [ApiController]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientSerive _patientSerive;
        private readonly IStringLocalizer _localizer;

        public PatientsController(IPatientSerive patientSerive,IStringLocalizer<SharedResource> localizer)
        {
            _patientSerive = patientSerive;
            _localizer = localizer;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreatePatientAsync([FromBody]CreatePatientRequest patientRequest)
        {
            var reponse = await _patientSerive.CreatePatientAsync(patientRequest);
            if (!reponse.Success)
            {
                return BadRequest(new { message = _localizer["PatientCantCreated"].Value, reponse });
            }
            return Ok(new { message = _localizer["PatientCreated"].Value });
            
        }
    }
}
