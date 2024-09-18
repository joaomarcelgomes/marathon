using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users.Interfaces;
using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services.Users;

public class GetAllUsersService(IUserRepository repository) : IGetAllUsersService
{
    public async Task<List<User>> All()
        => await repository.All();
}