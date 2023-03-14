using System.Net;

namespace WithMiddleware.Middlewares.Exceptions.Base;

public class HttpException : Exception
{
    protected HttpException(HttpStatusCode statusCode, string message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public override string Message { get; }

    public HttpStatusCode StatusCode { get; }
}