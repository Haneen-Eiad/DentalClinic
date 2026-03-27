using DentalClinic.ADL.DTOs.Request.Auth;
using DentalClinic.ADL.DTOs.Response.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinic.BLL.Service.Authntication
{
    public interface IAuthnticationService
    { 
        Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
        Task<bool> ConfirmEmailAsync(string Token, string UserId);
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
