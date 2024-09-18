namespace Backend.Domain.Api.Models.Requests.Teams;

public class InsertUsersInTeamRequest
{
    public List<int> UsersIds { get; set; }
}