namespace Backend.Domain.Service.Services.Matches.Interfaces;

public interface IDefineWinnerMatchService
{
    public Task DefineWinner(int teamId, int matchId);
}