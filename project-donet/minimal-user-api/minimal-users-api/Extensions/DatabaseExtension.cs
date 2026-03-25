using Microsoft.EntityFrameworkCore;
using minimal_users_api.Db;

namespace minimal_users_api.Extensions;

public static class DatabaseExtension
{
  public static IServiceCollection AddPersistanceModule(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<AppDbContext>(options =>
      options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

    return services;
  }
}
