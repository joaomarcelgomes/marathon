namespace Backend.Domain.Service.Services.Interfaces;

public interface ICreateTeamService
{
    public Task Create(string name, string imageUrl, string shortName, List<string> members);
}