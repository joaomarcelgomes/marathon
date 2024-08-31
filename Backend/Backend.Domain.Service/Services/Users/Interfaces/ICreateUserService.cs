namespace Backend.Domain.Service.Services.Users.Interfaces;

public interface ICreateUserService
{
    public Task Create(string name, string avatar, string email, string password);
}