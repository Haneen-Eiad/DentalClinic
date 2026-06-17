using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.BLL.Service.Equipment_Folder;
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
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;
        private readonly IStringLocalizer _localizer;

        public EquipmentsController(IEquipmentService equipmentService,
            IStringLocalizer<SharedResource> localizer
            )
        {
            _equipmentService = equipmentService;
            _localizer = localizer;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateEquipmentAsync([FromBody ]CreateEquipmentRequest createEquipmentRequest)
        {
            var response = await _equipmentService.CreateEquipmentAsync(createEquipmentRequest);
            if (!response.Success)
            { return BadRequest(new { message = _localizer["EquipmentCantCreated"].Value, response }); }
            ;
            return Ok(new { message = _localizer["EquipmentCreated"].Value, response });
        }
    }
}
