using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Repositories;

public interface ICompetitionRepository
{
    public Task<bool> UserExists(int userId);
    public Task Create(Competition competition);
    public Task<Competition?> Find(int id);
    public Task<List<Competition>> All(int userId);
    public Task Edit(Competition competition);
    public Task Delete(Competition competition);
}