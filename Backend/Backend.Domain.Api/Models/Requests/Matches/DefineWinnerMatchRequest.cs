namespace Backend.Domain.Api.Models.Requests.Matches;

public class DefineWinnerMatchRequest
{
    public int TeamId { get; set; }
    public int MatchId { get; set; }
}