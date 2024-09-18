namespace Backend.Domain.Api.Models.Requests.Users;

public class UserLoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}