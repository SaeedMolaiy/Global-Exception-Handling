using System.Net;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WithExceptionFilterAttribute.Filters;

[AttributeUsage(AttributeTargets.Class)]
public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
{
    /// <inheritdoc />
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Title = nameof(exception),
            Detail = exception.Message,
            Instance = context.HttpContext.Request.Path,
            Status = (int)HttpStatusCode.Conflict,
        };

        context.Result = new OkObjectResult(problemDetails);
        context.ExceptionHandled = true;
    }
}