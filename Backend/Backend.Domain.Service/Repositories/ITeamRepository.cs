using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Repositories;

public interface ITeamRepository
{
    public Task<List<Team>> All();
    public Task<List<Team>> Search(string text);
    public Task<Team> Find(int teamId);
    public Task Create(string name, string urlImage, string shortName, string members);
    public Task Edit(Team team);
    public Task Delete(int teamId);
}