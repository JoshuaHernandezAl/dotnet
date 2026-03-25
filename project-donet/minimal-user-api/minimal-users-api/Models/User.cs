using System;
using System.ComponentModel.DataAnnotations;

namespace minimal_users_api.Models;

public class User
{
  [Key]
  public Guid Id { get; set; }
  
  [Required]
  [MaxLength(50)]
  public required string Name { get; set; }
  
  [Required]
  [MaxLength(50)]
  public required string LastName { get; set; }
  [Required]
  [EmailAddress]
  public required string Email { get; set; }

  [Required]
  [Range(0,150, ErrorMessage = "Age must be between 0 and 150")]
  public required int Age { get; set; }
  public bool IsActive { get; set; } = false;
  public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
