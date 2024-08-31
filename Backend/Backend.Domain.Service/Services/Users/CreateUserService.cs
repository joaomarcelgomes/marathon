using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users.Interfaces;

namespace Backend.Domain.Service.Services.Users;

public class CreateUserService(IUserRepository repository) : ICreateUserService
{
    public async Task Create(string name, string avatar, string email, string password)
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
        
        await repository.Create(name, avatar, email, password);
    }
}