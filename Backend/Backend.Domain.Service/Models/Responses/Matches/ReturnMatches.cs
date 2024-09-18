using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Models.Responses.Matches;

public class ReturnMatches
{
    public List<Match> QuarterFinals { get; set; }
    public List<Match> SemiFinals{ get; set; }
    public List<Match> Finals { get; set; }
}