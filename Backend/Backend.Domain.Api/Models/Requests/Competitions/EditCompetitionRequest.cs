namespace Backend.Domain.Api.Models.Requests.Competitions;

public class EditCompetitionRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Prize { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}