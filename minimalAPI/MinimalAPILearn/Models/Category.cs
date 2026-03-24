using System;

namespace MinimalAPILearn.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime AddedDate { get; set; }
}
