using PruebaService_Common.Interfaces;
using System.Text.Json.Serialization;

namespace PruebaService_App.ViewModels
{
    public class ResultViewModel : IResult
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("detailMessage")]
        public string DetailMessage { get; set; }
    }

    public class ResultViewModel<T> : ResultViewModel where T : class
    {
        [JsonPropertyName("results")]
        public T Data { get; set; }

        public ResultViewModel()
        {

        }

        public ResultViewModel(T data, int code = 0, string message = "Se ha consumido el servicio correctamente")
        {
            Code = code;
            Message = DetailMessage = message;
            Data = data;
        }
    }
}
