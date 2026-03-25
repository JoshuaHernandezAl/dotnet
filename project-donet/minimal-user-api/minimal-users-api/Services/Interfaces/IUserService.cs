
using minimal_users_api.Dtos;
using minimal_users_api.Models;

namespace minimal_users_api.Services.Interfaces;

public interface IUserService
{
  public Task<User> CreateUser(CreateUserDTO userDTO);
  public Task<IEnumerable<User>> GetAllUsers();
  public Task<User> GetUserById(Guid id);
  public Task<User> UpdateUser(Guid id, UpdateUserDTO updateUserDTO);
  public Task<bool> DeleteUser(Guid id);
}
