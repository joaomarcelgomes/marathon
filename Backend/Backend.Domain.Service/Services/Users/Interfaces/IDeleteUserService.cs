namespace Backend.Domain.Service.Services.Users.Interfaces;

public interface IDeleteUserService
{
    public Task Delete(int id);
}