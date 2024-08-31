namespace Backend.Domain.Api.Models.Requests;

public class UserCreateRequest
{
    public string Name { get; set; }
    public string Avatar { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}