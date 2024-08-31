namespace Backend.Domain.Service.Services.Users.Interfaces;

public interface ILoginUserService
{
    public Task<bool> Login(string email, string password);
}