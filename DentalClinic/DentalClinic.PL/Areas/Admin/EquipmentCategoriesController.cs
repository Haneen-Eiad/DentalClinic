using DentalClinic.ADL.DTOs.Request.Create;
using DentalClinic.BLL.Service.EquipmentCategories_Folder;
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
    public class EquipmentCategoriesController : ControllerBase
    {
        private readonly IEquipmentCategoriesService _equipmentCategoriesService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public EquipmentCategoriesController(IEquipmentCategoriesService equipmentCategoriesService,
            IStringLocalizer<SharedResource> localizer
            )
        {
            _equipmentCategoriesService = equipmentCategoriesService;
            _localizer = localizer;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateEquipmentCategoriesAsync([FromBody] CreateEquipmentCategoriesRequest request)
        {
            var response = await _equipmentCategoriesService.CreateEquipmentCategoriesAsync(request);
            if (!response.Success)
            { return BadRequest(new { message = _localizer["EquipmentCategoriesCantCreated"].Value, response }); };
            return Ok (new {message = _localizer["EquipmentCategoriesCreated"].Value, response});


        }
    }
}
