using System.Net;

namespace minimal_users_api.Exceptions;

public class ExceptionMiddleware
{
  private readonly RequestDelegate _next;

  public ExceptionMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception ex)
    {
      await HandleExceptionAsync(context, ex);
    }
  }

  private static Task HandleExceptionAsync(HttpContext context, Exception exception)
  {
    context.Response.ContentType = "application/json";

    var customException = exception as BaseException;

    var statusCode = customException?.StatusCode ?? (int)HttpStatusCode.InternalServerError;
    context.Response.StatusCode = statusCode;

    var response = new
    {
      success = false,
      error = new
      {
        message = exception.Message,
        type = exception.GetType().Name,
        details = customException?.ErrorData
      }
    };

    return context.Response.WriteAsJsonAsync(response);
  }
}