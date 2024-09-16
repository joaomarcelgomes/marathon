using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services.Teams.Interfaces;

public interface ISearchTeamService
{
    public Task<List<Team>> All();
    public Task<List<Team>> Search(string text);
    public Task<Team> Find(int teamId);
}