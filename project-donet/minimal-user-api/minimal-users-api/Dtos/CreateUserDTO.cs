namespace minimal_users_api.Dtos;


public class CreateUserDTO
{
  public string? Name { get; set; }
  public string? LastName { get; set; }
  public string? Email { get; set; }
  public int? Age { get; set; }
}