using DentalClinic.ADL.DTOs.Request.Auth;
using DentalClinic.BLL.Service.Authntication;
using DentalClinic.PL.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DentalClinic.PL.Areas.Identity
{
    [Route("api/auth/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthnticationService _authnticationService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public AccountsController(IAuthnticationService authnticationService,
            IStringLocalizer<SharedResource> localizer
            
            )
        {
            _authnticationService = authnticationService;
            _localizer = localizer;
        }
        // ارحع اشتخدم ال localozatin
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
        // ارحع اشتخدم ال localozatin
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

        //Login controller
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
           var result = await _authnticationService.LoginAsync(loginRequest);
            if(!result.Success)
            {
                return BadRequest(new {message = _localizer["LoginFailed"].Value });
            }    
            return Ok(new {message = _localizer["LoginSuccess"].Value });
        
        }
    }
}
