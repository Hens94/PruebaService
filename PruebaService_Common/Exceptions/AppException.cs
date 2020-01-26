using System.Net;
using System.Runtime.Serialization;

namespace System
{
    public class AppException : BaseException
    {
        public AppException(
            string message = "Ha ocurrido un error no controlado",
            int resultCode = 999,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string detailMessage = null) : base(message, resultCode, statusCode, detailMessage, nameof(AppException))
        {
        }

        public AppException(
            Exception exception,
            string message = "Ha ocurrido un error no controlado",
            int resultCode = 999,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string detailMessage = null) : base(exception, message, resultCode, statusCode, detailMessage, nameof(AppException))
        {
        }

        protected AppException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}
