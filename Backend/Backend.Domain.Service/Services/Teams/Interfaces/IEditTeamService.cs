namespace Backend.Domain.Service.Services.Interfaces;

public interface IEditTeamService
{
    public Task EditTeam(int id, string name, string shortName, string urlImage, List<string> members);
}