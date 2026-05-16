using DentalClinic.ADL.DTOs.Request;
using DentalClinic.BLL.Service.SupplierService_Folder;
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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _service;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public SuppliersController(ISupplierService service, IStringLocalizer<SharedResource> localizer)
        {
            _service = service;
            _localizer = localizer;
        }

        [HttpPost("")]
        public async Task<IActionResult> createSupplierAsync([FromBody] CreateSupplierRequest supplierRequest)
        {
            var response = await _service.CreateSupplierAsync(supplierRequest);
            if (!response.Success)
            {
                return BadRequest(new { message = _localizer["SupplierCantBeCreated"].Value });
            }
            return Ok(new { message = _localizer["SupplierCreated"].Value });
        }
    }
}
