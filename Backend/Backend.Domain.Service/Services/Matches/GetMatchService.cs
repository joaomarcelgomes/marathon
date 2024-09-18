using Backend.Domain.Service.Models.Responses.Matches;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Matches.Interfaces;

namespace Backend.Domain.Service.Services.Matches;

public class GetMatchService(IMatchRepository repository) : IGetMatchService
{
    public async Task<ReturnMatches> GetMatches(int competitionId)
    {
        var matches = await repository.FindMatches(competitionId);
        
        return new ReturnMatches
        {
            SemiFinals = matches.Where(x => x.Type == "semifinals").ToList(),
            QuarterFinals = matches.Where(x => x.Type == "quarterfinals").ToList(),
            Finals = matches.Where(x => x.Type == "finals").ToList()
        };
    }
}