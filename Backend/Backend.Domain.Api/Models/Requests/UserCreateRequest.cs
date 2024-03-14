namespace Backend.Domain.Api.Models;

public class UserCreateRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}