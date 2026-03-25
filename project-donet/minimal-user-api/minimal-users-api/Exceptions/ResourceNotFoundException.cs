namespace minimal_users_api.Exceptions;

public class ResourceNotFoundException(string message, object? details = null) 
    : BaseException(message, 404, details);