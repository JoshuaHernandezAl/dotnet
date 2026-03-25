using AutoMapper;
using minimal_users_api.Dtos;
using minimal_users_api.Dtos.Responses;
using minimal_users_api.Filters;
using minimal_users_api.Services.Interfaces;

namespace minimal_users_api.Router;

public static class UsersRoutes
{
  public static void MapUserRoutes(this IEndpointRouteBuilder app)
  {
    var usersGroup = app.MapGroup("/users");

    usersGroup.MapPost("/", async (CreateUserDTO user, IUserService userService, IMapper mapper) =>
    {
      var userCreated = await userService.CreateUser(user);
      var reponseDTO = mapper.Map<CreateUserResponseDTO>(userCreated);

      return Results.Created($"/users/{userCreated.Id}", reponseDTO);
    }).AddEndpointFilter<ValidationFilter<CreateUserDTO>>();

    usersGroup.MapGet("/", async (IUserService userService, IMapper mapper) =>
    {
      var users = await userService.GetAllUsers();
      var responseDTO = mapper.Map<GetAllUsersResponseDTO>(users);
      return Results.Ok(responseDTO);
    });

    usersGroup.MapGet("/{id:guid}", async (Guid id, IUserService userService) =>
    {
      return Results.Ok(await userService.GetUserById(id));
    });

    usersGroup.MapPut("/{id:guid}", async (Guid id, UpdateUserDTO updateUserDTO, IUserService userService) =>
    {
      return Results.Ok(await userService.UpdateUser(id, updateUserDTO));
    });

    usersGroup.MapDelete("/{id:guid}", async (Guid id, IUserService userService) =>
    {
      await userService.DeleteUser(id);
      return Results.Ok(new { Message = $"User with id {id} deleted successfully"});
    });

  }
}
