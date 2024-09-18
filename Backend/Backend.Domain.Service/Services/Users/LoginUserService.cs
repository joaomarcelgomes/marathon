using Backend.Domain.Auth.Auth;
using Backend.Domain.Service.Models.Responses;
using Backend.Domain.Service.Models.Responses.Users;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users.Interfaces;

namespace Backend.Domain.Service.Services.Users;

public class LoginUserService(IUserRepository repository) : ILoginUserService
{
    private readonly TokenService _token = new();
    
    public async Task<(ReturnUserModel, string token)> Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("O e-mail informado é inválido");
        
        if(string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("A senha precisa ter pelo menos 8 caracteres");
        
        var user = await repository.GetUser(email, password);
        
        if (user is null)
            throw new InvalidOperationException("Usuário não encontrado");
        
        var token = _token.Generate(user.Id, user.Email);
        
        var model = new ReturnUserModel(user.Id, user.Name, user.Avatar, user.Email);
        
        return (model, token);
    }
}