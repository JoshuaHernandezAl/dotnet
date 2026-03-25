using minimal_users_api.Router;

namespace minimal_users_api.Extensions;

public static class IndexRouter
{
  public static void AllRoutesMapper(this IEndpointRouteBuilder app)
  {
    app.MapUserRoutes();
  }
}
