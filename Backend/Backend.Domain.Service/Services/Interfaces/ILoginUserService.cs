namespace Backend.Domain.Service.Services.Interfaces;

public interface ILoginUserService
{
    public Task<bool> Login(string email, string password);
}