using System.Net;

using Newtonsoft.Json;

using WithMiddleware.Middlewares.Exceptions;

namespace WithMiddleware.Middlewares;

public class GlobalErrorHandlingMiddleware
{
    private readonly RequestDelegate _requestDelegate;

    public GlobalErrorHandlingMiddleware(RequestDelegate requestDelegate)
    {
        _requestDelegate = requestDelegate;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _requestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionsAsync(httpContext, exception);
        }
    }

    protected Task HandleExceptionsAsync(HttpContext httpContext, Exception exception)
    {
        var response = GenerateHttpResponse(exception);

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = (int)response.httpStatusCode;

        return httpContext.Response.WriteAsync(response.json);
    }

    private static (HttpStatusCode httpStatusCode, string json) GenerateHttpResponse(Exception exception)
    {
        return exception switch
        {
            InvalidUserDataException invalidUserDataException => (invalidUserDataException.StatusCode, JsonConvert.SerializeObject(new { error = exception.Message })),

            _ => throw new ArgumentOutOfRangeException(nameof(exception), exception, null)
        };
    }
}