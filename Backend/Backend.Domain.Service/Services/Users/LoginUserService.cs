using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users.Interfaces;

namespace Backend.Domain.Service.Services.Users;

public class LoginUserService(IUserRepository repository) : ILoginUserService
{
    public async Task<bool> Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            throw new ArgumentException("O e-mail informado é inválido");
        
        if(string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("A senha precisa ter pelo menos 8 caracteres");
        
        return await repository.Login(email, password);
    }
}