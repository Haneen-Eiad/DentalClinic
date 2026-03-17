using Microsoft.AspNetCore.Diagnostics;

namespace DentalClinic.PL
{
    public class AppConfiguration
    {
        public static void Config(IServiceCollection services)
        {
            services.AddExceptionHandler<GlobalExcpetionHandler>();
            services.AddProblemDetails();
        }
    }
}
