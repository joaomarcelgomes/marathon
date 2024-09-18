using Backend.Domain.Service.Models.Responses.Matches;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Matches.Interfaces;
using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services.Matches;

public class CreateMatchService(IMatchRepository repository) : ICreateMatchService
{
    public async Task<ReturnMatches> Create(int competitionId)
    {
        var competition = await repository.Find(competitionId);
        
        if (competition == null)
            throw new Exception("Competição não encontrada");

        if (competition.Teams.Count % 2 != 0)
            throw new Exception("Número de times inválido");
        
        Shuffle(competition.Teams);
        
        var type = GetMatchType(competition.Teams.Count);
        
        var matches = new List<Match>();
        
        for (var i = 0; i < competition.Teams.Count; i += 2)
        {
            var match = new Match
            {
                CompetitionId = competitionId,
                Team1Id = competition.Teams[i].Id,
                Team2Id = competition.Teams[i + 1].Id,
                TeamWinnerId = null,
                Type = type
            };
            
            matches.Add(match);
        }
        
        await repository.Create(matches);
        
        return new ReturnMatches
        {
            SemiFinals = matches.Where(x => x.Type == "semifinals").ToList(),
            QuarterFinals = matches.Where(x => x.Type == "quarterfinals").ToList(),
            Finals = matches.Where(x => x.Type == "finals").ToList()
        };
    }

    private static void Shuffle<T>(IList<T> list)
    {
        var rng = new Random();
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = rng.Next(n + 1);
            (list[k], list[n]) = (list[n], list[k]);
        }
    }
    
    private static string GetMatchType(int count)
    {
        return count switch
        {
            8 => "quarterfinals",
            4 => "semifinals",
            2 => "finals",
            _ => throw new InvalidOperationException("Competição inválida")
        };
    }
}