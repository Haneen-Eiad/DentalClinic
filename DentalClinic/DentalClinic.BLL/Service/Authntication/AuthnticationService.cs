using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
using DentalClinic.ADL.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Authntication
{
    public class AuthnticationService : IAuthnticationService
        
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;

        public AuthnticationService(UserManager<ApplicationUser> userManager,
            IEmailSender emailSender
            )
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }
        public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            var User = registerRequest.Adapt<ApplicationUser>();
            var result = await _userManager.CreateAsync(User, registerRequest.Password);

            if(!result.Succeeded)
            {
                return new RegisterResponse
                {
                    Success = false,
                    Message = " Registration Faild",
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            await _userManager.AddToRoleAsync(User, "Patient");
            // send email for register confermation 
            var Token = await _userManager.GenerateEmailConfirmationTokenAsync(User);
            Token = Uri.EscapeDataString(Token);
            var EmailUrl = $"https://localhost:7028/api/auth/Accounts/ConfirmEmail?Token={Token}&UserId={User.Id}";
            await _emailSender.SendEmailAsync(User.Email, "Register Confirmation", $"<h1>Welcome at Dental Clinic {User.UserName}</h1>" +
                $"<a href='{EmailUrl}' style='padding:10px;background:#4CAF50;color:white;text-decoration:none;'>Confirm Email</a>");

             
            return new RegisterResponse
            {
                Success = true,
                Message = " Register Successfully"

            };
            

        }
        public async Task<bool> ConfirmEmailAsync(string Token, string UserId)
        {
            var User = await _userManager.FindByIdAsync(UserId);
            if(User is null) { return false; }
            // to decode the url and back it to the original shape with + / - ....
            Token = Uri.UnescapeDataString(Token);
            var result = await _userManager.ConfirmEmailAsync(User, Token);
            if(!result.Succeeded) { return false; }
            return true;
        } 
    }
}
