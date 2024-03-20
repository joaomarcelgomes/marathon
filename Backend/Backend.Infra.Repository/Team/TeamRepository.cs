using Backend.Domain.Service.Repositories;
using Backend.Infra.EntityLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repository.Team;

public class TeamRepository(DataContext context) : ITeamRepository
{
    public async Task<List<EntityLibrary.Entities.Team>> All()
        => await context.Teams.AsNoTracking().ToListAsync();

    public async Task<List<EntityLibrary.Entities.Team>> Search(string text)
        => await context.Teams
            .AsNoTracking()
            .Where(x => 
                x.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase) || 
                x.ShortName.Contains(text, StringComparison.CurrentCultureIgnoreCase) ||
                x.Members.Contains(text, StringComparison.CurrentCultureIgnoreCase))
            .ToListAsync();

    public async Task<EntityLibrary.Entities.Team> Find(int teamId)
        => await context.Teams.AsNoTracking().FirstAsync(x => x.Id == teamId);

    public async Task Create(string name, string urlImage, string shortName, string members)
    {
        var team = new EntityLibrary.Entities.Team
        {
            Name = name,
            ImageUrl = urlImage,
            ShortName = shortName,
            Members = members,
            CreatedAt = DateTime.Now
        };
        
        await context.Teams.AddAsync(team);
        await context.SaveChangesAsync();
    }
    
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