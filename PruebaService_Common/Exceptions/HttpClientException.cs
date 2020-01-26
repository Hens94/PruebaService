using System.Net;
using System.Runtime.Serialization;

namespace System
{
    [Serializable]
    public class HttpClientException : BaseException
    {
        public HttpClientException(
            string message = "Ha ocurrido un error no controlado",
            int resultCode = 999,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string detailMessage = null) : base(message, resultCode, statusCode, detailMessage, nameof(HttpClientException))
        {
        }

        public HttpClientException(
            Exception exception,
            string message = "Ha ocurrido un error no controlado",
            int resultCode = 999,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string detailMessage = null) : base(exception, message, resultCode, statusCode, detailMessage, nameof(HttpClientException))
        {
        }

        protected HttpClientException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}
