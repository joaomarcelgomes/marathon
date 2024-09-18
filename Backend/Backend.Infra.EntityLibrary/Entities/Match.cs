namespace Backend.Infra.EntityLibrary.Entities;

public class Match
{
    public int Id { get; set; }
    public int CompetitionId { get; set; }
    public int Team1Id { get; set; }
    public int Team2Id { get; set; }
    public int? TeamWinnerId { get; set; }
    public string Type { get; set; }
}