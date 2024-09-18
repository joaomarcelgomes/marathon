using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Matches.Interfaces;

namespace Backend.Domain.Service.Services.Matches;

public class DefineWinnerMatchService(IMatchRepository repository) : IDefineWinnerMatchService
{
    public async Task DefineWinner(int teamId, int matchId)
    {
        var match = await repository.FindMatch(matchId);
        
        if (match == null)
            throw new ArgumentException("Partida não encontrada");

        if (match.TeamWinnerId != null)
            throw new ArgumentException("O vencedor já foi definido");

        if (match.Team1Id != teamId && match.Team2Id != teamId)
            throw new ArgumentException("Este time não pode ser o vencedor");
        
        match.TeamWinnerId = teamId;
        await repository.Update(match);
    }
}