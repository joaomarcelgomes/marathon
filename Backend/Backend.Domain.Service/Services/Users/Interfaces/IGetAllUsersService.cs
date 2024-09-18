using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services.Users.Interfaces;

public interface IGetAllUsersService
{
    public Task<List<User>> All();
}