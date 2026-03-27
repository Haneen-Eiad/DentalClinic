using DentalClinic.ADL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Add this using directive

namespace DentalClinic.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var values = await _context.Treatment.ToListAsync(); // Use ToListAsync for async operation
            return Ok(values);
        }
    }
}
