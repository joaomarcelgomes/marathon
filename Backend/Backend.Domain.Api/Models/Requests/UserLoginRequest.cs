namespace Backend.Domain.Api.Models.Requests;

public class UserLoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}