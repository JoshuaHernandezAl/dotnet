namespace minimal_users_api.Dtos;


public class CreateUserDTO
{
  public required string Name { get; set; }
  public required string LastName { get; set; }
  public required string Email { get; set; }
  public int Age { get; set; }
}