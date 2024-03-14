namespace Backend.Domain.Service.Repositories;

public interface IUserRepository
{
    public Task Create(string name, string email, string password);
    public Task<bool> EmailExists(string email);
    public Task<bool> Login(string email, string password);
}