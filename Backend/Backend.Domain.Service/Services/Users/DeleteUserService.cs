using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users.Interfaces;

namespace Backend.Domain.Service.Services.Users;

public class DeleteUserService(IUserRepository repository) : IDeleteUserService
{
    public async Task Delete(int id)
    {
        var user = await repository.GetUser(id);
        
        if (user is null)
            throw new ArgumentException("Usuário não encontrado");
        
        await repository.Delete(user);
    }
}