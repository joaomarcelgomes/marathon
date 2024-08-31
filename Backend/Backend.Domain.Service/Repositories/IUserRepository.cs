using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Repositories;

public interface IUserRepository
{
    public Task<User> Create(string name, string avatar, string email, string password);
    public Task<bool> EmailExists(string email);
    public Task<User> GetUser(string email, string password);
    public Task<User> GetUser(int id);
}