namespace minimal_users_api.Exceptions;

public abstract class BaseException(string message, int statusCode, object? errorData = null) : Exception(message)
{
  public int StatusCode { get; } = statusCode;
  public object? ErrorData { get; } = errorData;
}