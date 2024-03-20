using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Interfaces;
using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services;

public class SearchTeamService(ITeamRepository repository) : ISearchTeamService
{
    public async Task<List<Team>> All() => await repository.All();

    public async Task<List<Team>> Search(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return await All();
        
        text = text.Trim();
        
        return await repository.Search(text);
    }

    public async Task<Team> Find(int teamId)
    {
        if (teamId <= 0)
            throw new ArgumentException("O id do time precisa ser maior que zero");
        
        return await repository.Find(teamId);
    }
}