using System.Net;

using WithMiddleware.Middlewares.Exceptions.Base;

namespace WithMiddleware.Middlewares.Exceptions;

public class InvalidUserDataException : HttpException
{
    private const HttpStatusCode HttpStatusCode = System.Net.HttpStatusCode.BadRequest;

    /// <inheritdoc />
    protected InvalidUserDataException(string message) : base(HttpStatusCode, message)
    {
    }
}