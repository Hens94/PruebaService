using PruebaService_Common.Interfaces;

namespace PruebaService_Common.Models
{
    public class Result : IResult
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string DetailMessage { get; set; }

        public Result() { }

        public Result(string message, int code = 999, string detailMessage = null)
        {
            Code = code;
            Message = message;
            DetailMessage = detailMessage ?? message;
        }
    }

    public class Result<T> : Result, IResult<T> where T : class
    {
        public T Data { get; set; }

        public Result() { }

        public Result(T data, int code = 0, string message = "Se ha obtenido la información correctamente")
        {
            Code = code;
            Message = DetailMessage = message;
            Data = data;
        }

        public Result(string message, int code = 999, string detailMessage = null)
        {
            Code = code;
            Message = message;
            DetailMessage = detailMessage ?? message;
            Data = null;
        }
    }
}
