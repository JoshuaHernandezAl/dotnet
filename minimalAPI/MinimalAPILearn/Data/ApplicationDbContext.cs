using Microsoft.EntityFrameworkCore;
using MinimalAPILearn.Models;

namespace MinimalAPILearn.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Models.Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Category 1",
                AddedDate = new DateTime(2024, 6, 1)
            },
            new Category
            {
                Id = 2,
                Name = "Category 2",
                AddedDate = new DateTime(2024, 6, 2)
            },
            new Category
            {
                Id = 3,
                Name = "Category 3",
                AddedDate = new DateTime(2024, 6, 3)
            }
        );
    }
}