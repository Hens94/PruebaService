using PruebaService_Common.Interfaces;
using PruebaService_Common.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.ExceptionExtensions;

namespace PruebaService_App.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<IResult<T>> GetFromJson<T>(this Task<(string, HttpStatusCode)> response) where T : class =>
            await UseCatchExceptionAsync<IResult<T>, HttpClientException>(
                async execError =>
                {
                    (string json, HttpStatusCode statusCode) = await response;

                    return statusCode switch
                    {
                        HttpStatusCode.OK => new Result<T>(JsonSerializer.Deserialize<T>(json)),
                        _ => new Result<T>($"Ha ocurrido un error al momento de consumir el recurso de tercero ({(int)statusCode})")
                    };
                },
                $"Ha ocurrido un error no controlado al momento de convertir la respuesta a {typeof(T).Name}");
    }
}
