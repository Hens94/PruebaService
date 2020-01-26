using PruebaService_Api.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app) =>
            app.
                UseMiddleware<ErrorMiddleware>();
    }
}
