using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using minimal_users_api.Db;
using minimal_users_api.Exceptions;
using minimal_users_api.Models;
using minimal_users_api.Repositories.Interfaces;

namespace minimal_users_api.Repositories;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _context;

  public UserRepository(AppDbContext context)
  {
    _context = context;
  }
  public async Task CreateAsync(User user)
  {
    await _context.Users.AddAsync(user);
  }

  public async Task<IEnumerable<User>> GetAllAsync()
  {
    return await _context.Users.Where(u => u.IsActive).AsNoTracking().ToListAsync();
  }

  public async Task<User> GetByIdAsync(Guid id)
  {
    var user = await _context.Users
      .FirstOrDefaultAsync(u => u.Id == id && u.IsActive);

    return user ?? throw new ResourceNotFoundException($"User with id {id} not found");
  }

  public Task UpdateAsync(User user)
  {
    user.UpdatedAt = DateTime.UtcNow;
    return Task.CompletedTask;
  }

  public Task DeleteAsync(User user)
  {
    user.IsActive = false;
    user.UpdatedAt = DateTime.UtcNow;
    return Task.CompletedTask;
  }

  public async Task<bool> SaveChangesAsync()
  {
    return await _context.SaveChangesAsync() > 0;
  }

  public async Task<bool> UserExistsAsync(string email)
  {
    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    if (user is not null)
    {
      throw new DatabaseException($"User with email {email} already exists");
    }
    return false;
  }
}
