using Backend.Domain.Service.Repositories;
using Backend.Infra.EntityLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Entities = Backend.Infra.EntityLibrary.Entities;

namespace Backend.Infra.Repository.User;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<Entities.User?> Create(string name, string avatar, string email, string password)
    {
        var user = new Entities.User
        {
            Name = name,
            Avatar = avatar,
            Email = email,
            Password = password
        };
        
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> EmailExists(string email) 
        => await context.Users.AnyAsync(x => x.Email == email);
    
    public async Task<Entities.User?> GetUser(string email, string password)
        => await context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

    public async Task<List<Entities.User>> All()
        => await context.Users.ToListAsync();

    public Task<Entities.User?> GetUser(int id)
        => context.Users.FirstOrDefaultAsync(x => x.Id == id);

    public async Task Delete(Entities.User user)
    {
        context.Users.Remove(user);
        await context.SaveChangesAsync();
    }

    public Task Update(Entities.User user)
    {
        context.Users.Update(user);
        return context.SaveChangesAsync();
    }
}