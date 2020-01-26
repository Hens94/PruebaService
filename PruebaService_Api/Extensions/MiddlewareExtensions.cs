using Microsoft.AspNetCore.Http;
using PruebaService_App.ViewModels;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace PruebaService_Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static HttpContent ToErrorContent(this Exception exception)
        {
            var result = exception.ToErrorResult();
            var json = JsonSerializer.Serialize(result);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static ResultViewModel ToErrorResult(this Exception exception)
        {
            if (exception is BaseException)
            {
                var ex = (BaseException)exception;

                return new ResultViewModel
                {
                    Code = ex.ResultCode,
                    Message = ex.Message,
                    DetailMessage = ex.DetailMessage
                };
            }

            return new ResultViewModel
            {
                Code = 999,
                Message = "Ha ocurrido un error, favor contactarse con el administrador",
                DetailMessage = $"({exception.GetType().Name}) {exception.InnerException?.Message ?? exception.Message}"
            };
        }

        public static void AddApiErrorHeaders(this HttpContext context)
        {
            context.Response.Headers["Content-Type"] = new[] { "application/json" };
            context.Response.Headers["Cache-Control"] = new[] { "no-cache, no-store, must-revalidate" };
            context.Response.Headers["Pragma"] = new[] { "no-cache" };
            context.Response.Headers["Expires"] = new[] { "0" };
        }

        public static void AddApiStatusCode(this HttpContext context, Exception exception)
        {
            context.Response.StatusCode =
                exception is BaseException ?
                (exception as BaseException).StatusCode :
                (int)HttpStatusCode.InternalServerError;
        }
    }
}
