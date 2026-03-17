using DentalClinic.ADL.DTO.Response;
using Microsoft.AspNetCore.Diagnostics;

namespace DentalClinic.PL
{
    public class GlobalExcpetionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorDateiles = new ErrorDetailes()
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                StackTrace = exception.InnerException.Message,
                Message = "server error"
            };
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(ErrorDateiles);
            return true;
        }
    }
}
