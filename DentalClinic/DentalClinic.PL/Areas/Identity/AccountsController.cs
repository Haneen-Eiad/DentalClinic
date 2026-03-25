using DentalClinic.ADL.DTOs.Request;
using DentalClinic.BLL.Service.Authntication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalClinic.PL.Areas.Identity
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthnticationService _authnticationService;

        public AccountsController(IAuthnticationService authnticationService)
        {
            _authnticationService = authnticationService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
           var response =  await _authnticationService.RegisterAsync(request);
            if(!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
            
        }

        // its for register
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmailAsync([FromQuery] string Token,[FromQuery] string UserId)
        {
           var result =await _authnticationService.ConfirmEmailAsync(Token, UserId);
            //its temporary .. in the real work its will be redirect to the FE or according to the user need may be i can just show the message or use the FE redirect 
            if (!result)
            {
                return BadRequest(new
                {
                    Success = false,
                    message = "Email Confirmed Faild"
                });
            }

            return Ok(new {Success = true, message = " Email Confirmed Successfully"});

        }
    }
}
