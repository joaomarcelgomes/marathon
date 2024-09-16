using Backend.Domain.Service.Repositories;
using Backend.Infra.EntityLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repository.Competition;

public class CompetitionRepository(DataContext context) : ICompetitionRepository
{
    public Task<bool> UserExists(int userId)
        => context.Users.AsNoTracking().AnyAsync(user => user.Id == userId);

    public async Task Create(EntityLibrary.Entities.Competition competition)
    {
        await context.Competitions.AddAsync(competition);
        await context.SaveChangesAsync();
    }

    public async Task<EntityLibrary.Entities.Competition?> Find(int id)
        => await context.Competitions.FindAsync(id);

    public Task Edit(EntityLibrary.Entities.Competition competition)
    {
        context.Competitions.Update(competition);
        return context.SaveChangesAsync();
    }

    public async Task Delete(EntityLibrary.Entities.Competition competition)
    {
        context.Competitions.Remove(competition);
        await context.SaveChangesAsync();
    }
}