﻿namespace Backend.Infra.EntityLibrary.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
}