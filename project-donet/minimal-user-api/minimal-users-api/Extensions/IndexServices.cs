
using FluentValidation;
using minimal_users_api.Mappings;
using minimal_users_api.Repositories;
using minimal_users_api.Repositories.Interfaces;
using minimal_users_api.Services;
using minimal_users_api.Services.Interfaces;

namespace minimal_users_api.Extensions;

public static class IndexServices
{
  public static IServiceCollection AddAllServicesModule(this IServiceCollection services, IConfiguration configuration)
  {
    //Persistance
    services.AddPersistanceModule(configuration);

    //Services
    services.AddScoped<IUserService, UserService>();

    // Repositories
    services.AddScoped<IUserRepository, UserRepository>();

    //Validators
    services.AddValidatorsFromAssembly(typeof(IndexServices).Assembly);

    // AutoMapper
    services.AddAutoMapper(cfg=>{}, typeof(UserProfile).Assembly);

    return services;
  }
}
