using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using minimal_users_api.Db;
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
    return await _context.Users.Where(u => u.IsActive).ToListAsync();
  }

  public Task<User> GetByIdAsync(Guid id)
  {
    var user = _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.IsActive) ?? throw new KeyNotFoundException($"User with id {id} not found");
    return user!;
  }

  public Task UpdateAsync(User user)
  {
    var entry = AttachEntity(user);
    user.UpdatedAt = DateTime.UtcNow;
    entry.State = EntityState.Modified;
    return Task.CompletedTask;
  }

  public Task DeleteAsync(User user)
  {
    var entry = AttachEntity(user);
    user.IsActive = false;
    user.UpdatedAt = DateTime.UtcNow;
    entry.State = EntityState.Modified;
    return Task.CompletedTask;
  }

  public async Task<bool> SaveChangesAsync()
  {
    return await _context.SaveChangesAsync() > 0;
  }

  private EntityEntry<User> AttachEntity(User user)
  {
    var entry = _context.Entry(user);
    if (entry.State == EntityState.Detached) { _context.Users.Attach(user); }
    return entry;
  }

}
