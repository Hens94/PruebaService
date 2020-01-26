using PruebaService_Api.Middleware;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app) =>
            app.
                UseMiddleware<ErrorMiddleware>();
    }
}
