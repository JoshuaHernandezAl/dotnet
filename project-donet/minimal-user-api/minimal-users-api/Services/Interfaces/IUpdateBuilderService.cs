
using minimal_users_api.Dtos;
using minimal_users_api.Models;

namespace minimal_users_api.Services.Interfaces;

public interface IUpdateBuilderService
{
  public void BuildUpdates(UpdateUserDTO updateUserDTO, User user);
}
