using DentalClinic.ADL.DTOs.Request;
using DentalClinic.BLL.Service.Medicine_Folder;
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
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public MedicinesController(IMedicineService medicineService,IStringLocalizer<SharedResource> localizer)
        {
            _medicineService = medicineService;
            _localizer = localizer;
        }
        [HttpPost("")]
        public async Task<IActionResult> CreateMedicineAsync([FromBody]CreateMedicineRequest medicineRequest)
        {
            var response = await _medicineService.CreateMedicineAsync(medicineRequest);
            if (!response.Success)
            {
                return BadRequest(new {message = _localizer["MedicineCantCreate"].Value,response });
            }
            return Ok(new {message = _localizer["MedicineCreated"].Value, response });
        }
    }
}
