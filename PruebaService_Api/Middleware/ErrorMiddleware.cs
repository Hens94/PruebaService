using Microsoft.AspNetCore.Http;
using PruebaService_Api.Extensions;
using System;
using System.Text;
using System.Threading.Tasks;

namespace PruebaService_Api.Middleware
{
    public class ErrorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.AddApiErrorHeaders();
                context.AddApiStatusCode(ex);
                await context.Response.WriteAsync(await ex.ToErrorContent().ReadAsStringAsync(), Encoding.UTF8);
            }
        }
    }
}
