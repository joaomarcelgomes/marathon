namespace Backend.Domain.Service.Services.Competitions.Interfaces;

public interface IInsertTeamInCompetitionService
{
    public Task Insert(int competitionId, List<int> teamId);
}