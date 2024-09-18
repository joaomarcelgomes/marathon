using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions.Interfaces;

namespace Backend.Domain.Service.Services.Competitions;

public class InsertTeamInCompetitionService(ICompetitionRepository repository) : IInsertTeamInCompetitionService
{
    public async Task Insert(int competitionId, List<int> teamId)
    {
        var competition = await repository.Find(competitionId);
        
        if(competition == null)
            throw new ArgumentException("A competição não existe");
        
        var teams = await repository.FindTeam(teamId);
        
        if(teams == null)
            throw new ArgumentException("A equipe não existe");

        foreach (var team in teams)
        {
            var exists = competition.Teams.Exists(x => x.Id == team.Id);
            
            if(exists)
                continue;
            
            competition.Teams.Add(team);
        }
        
        await repository.Save();
    }
}