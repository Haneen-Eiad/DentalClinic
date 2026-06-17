using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.BLL.Service.PrescriptionItemService_Folder;
using DentalClinic.PL.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DentalClinic.PL.Areas.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionItemsController : ControllerBase
    {
        private readonly IPrescriptionItemService _prescriptionItemService;
        private readonly IStringLocalizer _localizer;

        public PrescriptionItemsController(IPrescriptionItemService prescriptionItemService
            ,IStringLocalizer<SharedResource> localizer
            )
        {
            _prescriptionItemService = prescriptionItemService;
            _localizer = localizer;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreatePrescriptionItemAsync([FromBody] CreatePrescriptionItemRequest request, [FromQuery] int prescriptionId)
        {
            var response = await _prescriptionItemService.CreatePrescriptionItemAsync(request, prescriptionId);
            if (!response.Success)
            {
                return BadRequest(new { message = _localizer["PrescriptionCantCreated"].Value, response });
            }
            return Ok(new { message = _localizer["PrescriptionCreated"].Value, response });
        }
    }
}
