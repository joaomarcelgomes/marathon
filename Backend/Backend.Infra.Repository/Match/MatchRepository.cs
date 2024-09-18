using Backend.Domain.Service.Repositories;
using Backend.Infra.EntityLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infra.Repository.Match;

public class MatchRepository(DataContext context) : IMatchRepository
{
    public async Task<EntityLibrary.Entities.Competition?> Find(int competitionId)
        => await context.Competitions.Include(x => x.Teams).FirstOrDefaultAsync(x => x.Id == competitionId);

    public async Task<List<EntityLibrary.Entities.Match>> FindMatches(int competitionId)
        => await context.Matches.Where(x => x.CompetitionId == competitionId).ToListAsync();

    public async Task Create(List<EntityLibrary.Entities.Match> match)
    {
        await context.Matches.AddRangeAsync(match);
        await context.SaveChangesAsync();
    }

    public async Task Update(EntityLibrary.Entities.Match match)
    {
        context.Matches.Update(match);
        await context.SaveChangesAsync();
    }

    public Task<EntityLibrary.Entities.Match?> FindMatch(int matchId)
        => context.Matches.FirstOrDefaultAsync(x => x.Id == matchId);
}