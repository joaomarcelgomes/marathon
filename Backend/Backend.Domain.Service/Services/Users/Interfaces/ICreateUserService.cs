namespace Backend.Domain.Service.Services.Users.Interfaces;

public interface ICreateUserService
{
    public Task Create(string name, string email, string password);
}