using Azure.Messaging;
using DentalClinic.ADL.Data;
using DentalClinic.PL.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DentalClinic.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<SharedResource> _localizer;

      public  ValuesController(ApplicationDbContext context, IStringLocalizer<SharedResource> localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        [HttpGet("")]
        public IActionResult GetResult()
        {
            return Ok(new { message = _localizer["LoginFailed"].Value });
        }

    }
}
