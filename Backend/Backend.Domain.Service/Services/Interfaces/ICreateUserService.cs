namespace Backend.Domain.Service.Services.Interfaces;

public interface ICreateUserService
{
    public Task Create(string name, string email, string password);
}