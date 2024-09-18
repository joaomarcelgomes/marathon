using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Teams.Interfaces;

namespace Backend.Domain.Service.Services.Teams;

public class InsertUserInTeamService(ITeamRepository repository) : IInsertUserInTeamService
{
    public async Task InsertUserInTeam(int teamId, List<int> usersIds)
    {
        var team = await repository.Find(teamId);
        
        if (team is null)
            throw new ArgumentException("Time não encontrado");
        
        var users = await repository.Find(usersIds);
        
        if (users.Count != usersIds.Count)
            throw new ArgumentException("Usuário não encontrado");

        foreach (var user in users)
        {
            var exists = team.Users.Exists(x => x.Id == user.Id);
            
            if (exists)
                continue;
            
            team.Users.Add(user);
        }

        await repository.Save();
    }
}