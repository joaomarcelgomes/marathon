using Backend.Domain.Service.Models.Responses;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users.Interfaces;

namespace Backend.Domain.Service.Services.Users;

public class ReturnUserService(IUserRepository repository) : IReturnUserService
{
    public async Task<ReturnUserModel> ReturnUser(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Usuário informado é inválido");
        
        var user = await repository.GetUser(id);
        
        if (user is null)
            throw new InvalidOperationException("Usuário não encontrado");
        
        return new ReturnUserModel(user.Id, user.Name, user.Avatar, user.Email);
    }
}