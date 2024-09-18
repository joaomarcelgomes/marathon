namespace Backend.Domain.Api.Models.Requests.Teams;

public class TeamCreateRequest
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public List<int> UsersIds { get; set; }
    public string ShortName { get; set; }
}