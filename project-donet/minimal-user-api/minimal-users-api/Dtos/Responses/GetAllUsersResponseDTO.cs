using minimal_users_api.Models;

namespace minimal_users_api.Dtos.Responses;

public record GetAllUsersResponseDTO(
  List<User> Users
);