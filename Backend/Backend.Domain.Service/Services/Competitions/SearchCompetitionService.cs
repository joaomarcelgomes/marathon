using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions.Interfaces;
using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services.Competitions;

public class SearchCompetitionService(ICompetitionRepository repository) : ISearchCompetitionService
{
    public async Task<List<Competition>> SearchCompetitions(int userId)
    {
        if(userId <= 0)
            throw new ArgumentException("O id do usuário é inválido");
        
        var competitions = await repository.All(userId);
        
        return competitions;
    }
}