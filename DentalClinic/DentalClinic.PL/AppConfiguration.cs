using DentalClinic.ADL.Models;
using DentalClinic.ADL.Utilities;
using Microsoft.AspNetCore.Diagnostics;

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
        }
    }
}
