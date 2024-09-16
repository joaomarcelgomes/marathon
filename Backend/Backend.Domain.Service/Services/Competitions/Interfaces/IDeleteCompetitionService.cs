namespace Backend.Domain.Service.Services.Competitions.Interfaces;

public interface IDeleteCompetitionService
{
    public Task DeleteCompetition(int competitionId);
}