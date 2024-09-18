namespace Backend.Domain.Service.Services.Teams.Interfaces;

public interface IInsertUserInTeamService
{
    public Task InsertUserInTeam(int teamId, List<int> usersIds);
}