using minimal_users_api.Dtos;
using minimal_users_api.Models;
using minimal_users_api.Services.Interfaces;

namespace minimal_users_api.Services;

public class UpdateBuilderService: IUpdateBuilderService
{
  public void BuildUpdates(UpdateUserDTO updateUserDTO, User user)
  {
    if (updateUserDTO.Name is not null)
    {
      user.Name = updateUserDTO.Name;
    }
    if (updateUserDTO.LastName is not null)
    {
      user.LastName = updateUserDTO.LastName;
    }
    if (updateUserDTO.Age is not null)
    {
      user.Age = updateUserDTO.Age.Value;
    }
    if (updateUserDTO.IsActive is not null)
    {
      user.IsActive = updateUserDTO.IsActive.Value;
    }
  }
}
