using Microsoft.AspNetCore.Diagnostics;

namespace BasicCrmSystem_API.ErrorHandling
{
    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            ErrorResponse response = new ErrorResponse()
            {
                StatusCode = httpContext.Response.StatusCode,
                ExceptionMessage = exception.Message,
                Title = "Something went wrong"
            };


            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return (true);
        }
    }
}
