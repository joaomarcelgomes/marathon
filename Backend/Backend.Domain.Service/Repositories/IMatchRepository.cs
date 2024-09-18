using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Repositories;

public interface IMatchRepository
{
    public Task<Competition?> Find(int competitionId);
    public Task<List<Match>> FindMatches(int competitionId);
    public Task Create(List<Match> match);
    public Task Update(Match match);
    public Task<Match?> FindMatch(int matchId);
}