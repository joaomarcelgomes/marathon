namespace Backend.Infra.EntityLibrary.Entities;

public class Competition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public string Prize { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    
    public User User { get; set; }
    public List<Team> Teams { get; set; } = new List<Team>();
}