using Microsoft.AspNetCore.Mvc;

using WithExceptionFilterAttribute.Filters;

namespace WithExceptionFilterAttribute.Controllers;

[GlobalExceptionFilter]
public class BaseController : Controller
{
}
