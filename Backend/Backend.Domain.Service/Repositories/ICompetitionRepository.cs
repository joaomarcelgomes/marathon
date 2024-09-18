using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Repositories;

public interface ICompetitionRepository
{
    public Task<bool> UserExists(int userId);
    public Task Create(Competition competition);
    public Task Save();
    public Task<Competition?> Find(int id);
    public Task<Team?> FindTeam(int teamId);
    public Task<List<Team>> FindTeam(List<int> teamsIds);
    public Task<List<Competition>> All(int userId);
    public Task Edit(Competition competition);
    public Task Delete(Competition competition);
}