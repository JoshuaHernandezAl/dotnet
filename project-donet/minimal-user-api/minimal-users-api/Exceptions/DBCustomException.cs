namespace minimal_users_api.Exceptions;

public class DatabaseException(string message, object? details = null) 
    : BaseException(message, 409, details);