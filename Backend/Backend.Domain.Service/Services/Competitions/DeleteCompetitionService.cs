using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions.Interfaces;

namespace Backend.Domain.Service.Services.Competitions;

public class DeleteCompetitionService(ICompetitionRepository repository) : IDeleteCompetitionService
{
    public async Task DeleteCompetition(int competitionId)
    {
        if (competitionId <= 0)
            throw new ArgumentException("Competição inválida");
        
        var competition = await repository.Find(competitionId);
        
        if (competition == null)
            throw new ArgumentException("A competição não existe");
        
        await repository.Delete(competition);
    }
}