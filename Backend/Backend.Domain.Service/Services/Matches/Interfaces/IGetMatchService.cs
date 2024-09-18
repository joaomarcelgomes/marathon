using Backend.Domain.Service.Models.Responses.Matches;

namespace Backend.Domain.Service.Services.Matches.Interfaces;

public interface IGetMatchService
{
    public Task<ReturnMatches> GetMatches(int competitionId);
}