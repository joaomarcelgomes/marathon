namespace Backend.Domain.Service.Services.Users.Interfaces;

public interface IUpdateUserService
{
    public Task Update(int id, string name, string avatar, string email, string password);
}