using System;
using minimal_users_api.Models;

namespace minimal_users_api.Repositories.Interfaces;

public interface IUserRepository
{
  Task CreateAsync(User user);
  Task<bool> SaveChangesAsync();

  Task<IEnumerable<User>> GetAllAsync();
  Task<User> GetByIdAsync(Guid id);
  Task<bool> UserExistsAsync(string email);
  Task UpdateAsync(User user);
  Task DeleteAsync(User user);
}
