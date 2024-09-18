using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Teams.Interfaces;

namespace Backend.Domain.Service.Services.Teams;

public class RemoveUserOfTeamService(ITeamRepository repository) : IRemoveUserOfTeamService
{
    public async Task RemoveUserOfTeam(int teamId, int userId)
    {
        var team = await repository.Find(teamId);
        
        if (team is null)
            throw new ArgumentException("Time não encontrado");
        
        if(team.Users.Count == 1)
            throw new ArgumentException("O time deve ter pelo menos um usuário");
        
        var user = await repository.FindUser(userId);
        
        if (user is null)
            throw new ArgumentException("Usuário não encontrado");

        team.Users.Remove(user);
        user.Team = null!;

        await repository.Save();
    }
}