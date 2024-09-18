namespace Backend.Domain.Service.Services.Competitions.Interfaces;

public interface IEditCompetitionService
{
    public Task EditCompetition(int competitionId, string name, string description, string prize, DateTime start, DateTime end);
}