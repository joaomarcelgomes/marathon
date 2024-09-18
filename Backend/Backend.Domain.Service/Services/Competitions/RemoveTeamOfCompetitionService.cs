using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions.Interfaces;

namespace Backend.Domain.Service.Services.Competitions;

public class RemoveTeamOfCompetitionService(ICompetitionRepository repository) : IRemoveTeamOfCompetitionService
{
    public async Task Remove(int competitionId, int teamId)
    {
        var competition = await repository.Find(competitionId);
        
        if(competition == null)
            throw new ArgumentException("A competição não existe");

        var team = await repository.FindTeam(teamId);
        
        if(team == null)
            throw new ArgumentException("A equipe não existe");

        var exists = competition.Teams.Exists(x => x.Id == teamId);
        
        if(!exists)
            throw new ArgumentException("A equipe não está na competição");
        
        competition.Teams.Remove(team);
        
        await repository.Save();
    }
}