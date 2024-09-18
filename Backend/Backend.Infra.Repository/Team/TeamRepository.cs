using Backend.Domain.Service.Repositories;
using Backend.Infra.EntityLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repository.Team;

public class TeamRepository(DataContext context) : ITeamRepository
{
    public async Task<List<EntityLibrary.Entities.Team>> All()
        => await context.Teams.Include(x => x.Users).ToListAsync();

    public async Task Save()
    {
        await context.SaveChangesAsync();
    }

    public async Task<List<EntityLibrary.Entities.Team>> Search(string text)
        => await context.Teams
            .Include(x => x.Users)
            .Where(x => 
                x.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase) || 
                x.ShortName.Contains(text, StringComparison.CurrentCultureIgnoreCase) ||
                x.Users.Any(user => user.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase) || 
                                    user.Email.Contains(text, StringComparison.CurrentCultureIgnoreCase)))
            .ToListAsync();

    public async Task<EntityLibrary.Entities.Team> Find(int teamId)
        => await context.Teams.Include(x => x.Users).FirstAsync(x => x.Id == teamId);

    public async Task Create(string name, string urlImage, string shortName, List<EntityLibrary.Entities.User> users)
    {
        var team = new EntityLibrary.Entities.Team
        {
            Name = name,
            ImageUrl = urlImage,
            ShortName = shortName,
            Users = users,
            CreatedAt = DateTime.Now
        };
        
        await context.Teams.AddAsync(team);
        await context.SaveChangesAsync();
    }

    public Task<List<EntityLibrary.Entities.User>> Find(List<int> usersIds)
        => context.Users.Where(x => usersIds.Contains(x.Id)).ToListAsync();

    public async Task<EntityLibrary.Entities.User?> FindUser(int userId)
        => await context.Users.FindAsync(userId);

    public async Task Edit(EntityLibrary.Entities.Team team)
    {
        context.Teams.Update(team);
        await context.SaveChangesAsync();
    }

    public Task Delete(int teamId)
    {
        var team = context.Teams.First(x => x.Id == teamId);
        
        context.Teams.Remove(team);
        return context.SaveChangesAsync();
    }
}