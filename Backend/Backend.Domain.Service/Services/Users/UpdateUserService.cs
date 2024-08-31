using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users.Interfaces;

namespace Backend.Domain.Service.Services.Users;

public class UpdateUserService(IUserRepository repository) : IUpdateUserService
{
    public async Task Update(int id, string name, string avatar, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 4)
            throw new ArgumentException("O nome do usuário precisa ter pelo menos 4 caracteres");

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            throw new ArgumentException("O e-mail informado é inválido");
        
        if(string.IsNullOrWhiteSpace(avatar))
            throw new ArgumentException("O avatar é obrigatório");
        
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            throw new ArgumentException("A senha precisa ter pelo menos 8 caracteres");

        var user = await repository.GetUser(id);
        
        if (user is null)
            throw new ArgumentException("Usuário não encontrado");
        
        user.Name = name;
        user.Avatar = avatar;
        user.Email = email;
        user.Password = password;
        
        await repository.Update(user);
    }
}