namespace minimal_users_api.Dtos;

public record UpdateUserDTO(
    string? Name,
    string? LastName,
    int? Age,
    bool? IsActive
);