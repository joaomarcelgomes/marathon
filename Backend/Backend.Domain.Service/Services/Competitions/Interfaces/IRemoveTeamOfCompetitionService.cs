namespace Backend.Domain.Service.Services.Competitions.Interfaces;

public interface IRemoveTeamOfCompetitionService
{
    public Task Remove(int competitionId, int teamId);
}