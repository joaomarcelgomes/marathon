namespace Backend.Domain.Service.Services.Teams.Interfaces;

public interface ICreateTeamService
{
    public Task Create(string name, string imageUrl, string shortName, List<int> usersIds);
}