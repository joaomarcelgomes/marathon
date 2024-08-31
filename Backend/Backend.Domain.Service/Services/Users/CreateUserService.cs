using Backend.Domain.Auth.Auth;
using Backend.Domain.Service.Models.Responses;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users.Interfaces;

namespace Backend.Domain.Service.Services.Users;

public class CreateUserService(IUserRepository repository) : ICreateUserService
{
    private readonly TokenService _token = new();
    
    public async Task<(ReturnUserModel, string token)> Create(string name, string avatar, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 4)
            throw new ArgumentException("O nome do usuário precisa ter pelo menos 4 caracteres");

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("O e-mail informado é inválido");
        
        if(string.IsNullOrWhiteSpace(avatar))
            throw new ArgumentException("O avatar é obrigatório");
        
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("A senha precisa ter pelo menos 8 caracteres");
        
        if (await repository.EmailExists(email))
            throw new InvalidOperationException("O e-mail informado já está em uso");
        
        var user = await repository.Create(name, avatar, email, password);
        
        if (user is null)
            throw new InvalidOperationException("Erro ao criar usuário");
        
        var returnUser = new ReturnUserModel(user.Id, user.Name, user.Avatar, user.Email);

        var token = _token.Generate(user.Id, user.Email);
        
        return (returnUser, token);
    }
}