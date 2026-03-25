using System.Text.Json;
using minimal_users_api.Exceptions;
using minimal_users_api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAllServicesModule(builder.Configuration);


builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

});


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
app.AllRoutesMapper();

app.UseHttpsRedirection();

app.Run();
