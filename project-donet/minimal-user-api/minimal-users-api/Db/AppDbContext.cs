using Microsoft.EntityFrameworkCore;
using minimal_users_api.Models;

namespace minimal_users_api.Db;

public class AppDbContext: DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
  { 
  }

  public DbSet<User> Users { get; set; }
}
