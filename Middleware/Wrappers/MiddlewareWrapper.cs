using Microsoft.AspNetCore.Builder;

namespace Roulette.Middleware.Wrappers
{
    public static class MiddlewareWrapper
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ProcessFailureResponseHandlerMiddleware>();
        }
    }
}
