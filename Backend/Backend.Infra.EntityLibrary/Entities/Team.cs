namespace Backend.Infra.EntityLibrary.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string ShortName { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<User> Users { get; set; } = new List<User>();
    public List<Competition> Competitions { get; set; } = new List<Competition>();
}