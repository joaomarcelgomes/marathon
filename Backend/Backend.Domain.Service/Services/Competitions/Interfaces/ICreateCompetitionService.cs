namespace Backend.Domain.Service.Services.Competitions.Interfaces;

public interface ICreateCompetitionService
{
    public Task Create(string name, string description, string prize, int userId, DateTime start, DateTime end, List<int> teamsIds);
}