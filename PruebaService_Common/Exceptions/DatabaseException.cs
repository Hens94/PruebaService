using System.Net;
using System.Runtime.Serialization;

namespace System
{
    [Serializable]
    public class DatabaseException : BaseException
    {
        public DatabaseException(
            string message = "Ha ocurrido un error no controlado",
            int resultCode = 999,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string detailMessage = null) : base(message, resultCode, statusCode, detailMessage, nameof(DatabaseException))
        {
        }

        public DatabaseException(
            Exception exception,
            string message = "Ha ocurrido un error no controlado",
            int resultCode = 999,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
            string detailMessage = null) : base(exception, message, resultCode, statusCode, detailMessage, nameof(DatabaseException))
        {
        }

        protected DatabaseException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}
