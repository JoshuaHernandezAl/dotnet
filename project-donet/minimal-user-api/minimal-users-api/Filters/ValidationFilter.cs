using System;
using FluentValidation;

namespace minimal_users_api.Filters;

public class ValidationFilter<T> : IEndpointFilter where T : class
{
  public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
  {
    var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>() ?? throw new Exception($"Validator not found for type {typeof(T).Name}");

    if (context.Arguments.FirstOrDefault(x => x is T) is not T model)
    {
      return Results.BadRequest(new { error = $"The model of type {typeof(T).Name} is null or invalid." });
    }

    var validationResult = await validator.ValidateAsync(model);

    if (!validationResult.IsValid)
    {
      return Results.ValidationProblem(validationResult.ToDictionary());
    }

    return await next(context);
  }
}
