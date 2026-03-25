using AutoMapper;
using minimal_users_api.Dtos;
using minimal_users_api.Exceptions;
using minimal_users_api.Models;
using minimal_users_api.Repositories.Interfaces;
using minimal_users_api.Services.Interfaces;

namespace minimal_users_api.Services;

public class UserService : IUserService
{

  private readonly IUserRepository _userRepository;
  private readonly IMapper _mapper;
  private readonly IUpdateBuilderService _updateBuilderService;

  public UserService(IUserRepository userRepository, IMapper mapper, IUpdateBuilderService updateBuilderService)
  {
    _userRepository = userRepository;
    _mapper = mapper;
    _updateBuilderService = updateBuilderService;
  }

  public async Task<User> CreateUser(CreateUserDTO userDTO)
  {
    var user = _mapper.Map<User>(userDTO);
    await _userRepository.CreateAsync(user);
    if (!await _userRepository.SaveChangesAsync())
    {
      throw new DatabaseException("Error saving the user to the database");
    }
    return user;
  }

  public async Task<IEnumerable<User>> GetAllUsers()
  {
    return await _userRepository.GetAllAsync();
  }

  public async Task<User> GetUserById(Guid id)
  {
    return await _userRepository.GetByIdAsync(id);
  }

  public async Task<User> UpdateUser(Guid id, UpdateUserDTO updateUserDTO)
  {
    var dbUser = await _userRepository.GetByIdAsync(id) ?? throw new ResourceNotFoundException($"User with id {id} not found");
    _updateBuilderService.BuildUpdates(updateUserDTO, dbUser);
    await _userRepository.UpdateAsync(dbUser);
    if (!await _userRepository.SaveChangesAsync())
    {
      throw new DatabaseException("Error updating the user in the database");
    }
    return dbUser;
  }

  public async Task<bool> DeleteUser(Guid id)
  {
    var dbUser = await _userRepository.GetByIdAsync(id) ?? throw new ResourceNotFoundException($"User with id {id} not found");
    await _userRepository.DeleteAsync(dbUser);
    if (!await _userRepository.SaveChangesAsync())
    {
      throw new DatabaseException("Error deleting the user from the database");
    }
    return true;
  }
}
