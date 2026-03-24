using Microsoft.EntityFrameworkCore;
using MinimalAPILearn.Data;
using MinimalAPILearn.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.MapGet("/api/categories", async(ApplicationDbContext db) =>
{   
    var categories = await db.Categories.ToListAsync();
    return Results.Ok(categories);
});

app.Run();
