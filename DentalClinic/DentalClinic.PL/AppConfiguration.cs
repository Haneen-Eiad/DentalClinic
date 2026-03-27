using DentalClinic.ADL.Models;
using DentalClinic.ADL.Utilities;
using DentalClinic.BLL.Service.Authntication;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace DentalClinic.PL
{
    public class AppConfiguration
    {
        public static void Config(IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExcpetionHandler>();
            services.AddProblemDetails();
            services.AddScoped<ISeedData, RoleSeedData>();
            services.AddScoped<ISeedData, UserSeedData>();
            services.AddScoped<ISeedData, SupplierSeedData>();
            services.AddScoped<ISeedData, TreatmentSeedData>();
            services.AddScoped<IAuthnticationService, AuthnticationService>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
