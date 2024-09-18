namespace Backend.Domain.Service.Services.Teams.Interfaces;

public interface IEditTeamService
{
    public Task EditTeam(int id, string name, string shortName, string urlImage);
}