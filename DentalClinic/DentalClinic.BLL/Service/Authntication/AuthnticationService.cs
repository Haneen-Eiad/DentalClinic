using DentalClinic.ADL.DTOs.Request.Auth;
using DentalClinic.ADL.DTOs.Response.Auth;
using DentalClinic.ADL.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Authntication
{
    public class AuthnticationService : IAuthnticationService
        
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public AuthnticationService(UserManager<ApplicationUser> userManager,
            IEmailSender emailSender, IConfiguration configuration
            )
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _configuration = configuration;
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
                Message = " Registration successful. Please check your email to confirm your account☻"

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
        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var User = await _userManager.FindByEmailAsync(loginRequest.Email);
            if(User is null)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = "Invalid Email",

                };

            }
           var result =  await _userManager.CheckPasswordAsync(User ,loginRequest.Password);
            if (!result)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = " wrong password"
                };
            }

            return new LoginResponse
            {
                Success = true,
                Message = "Login successfully",
                AccessToken = await GenerateAccessToken(User)
            };
             

        }
        private async Task<string> GenerateAccessToken(ApplicationUser user)
        {
            var role = await _userManager.GetRolesAsync(user);
            var UserClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,string.Join(',',role))

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecurityKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:_configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: UserClaims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
