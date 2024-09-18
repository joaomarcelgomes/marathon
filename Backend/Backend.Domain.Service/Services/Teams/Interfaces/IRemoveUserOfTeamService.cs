namespace Backend.Domain.Service.Services.Teams.Interfaces;

public interface IRemoveUserOfTeamService
{
    public Task RemoveUserOfTeam(int teamId, int userId);
}