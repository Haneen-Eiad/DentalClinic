using DentalClinic.ADL.DTOs.Request;
using DentalClinic.ADL.DTOs.Response;
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
    }
}
