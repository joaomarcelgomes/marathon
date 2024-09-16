using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions.Interfaces;
using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services.Competitions;

public class CreateCompetitionService(ICompetitionRepository repository) : ICreateCompetitionService
{
    public async Task Create(string name, string description, string prize, int userId, DateTime start, DateTime end)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome da competição é obrigatório");
        
        if(string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("A descrição da competição é obrigatória");
        
        if(string.IsNullOrWhiteSpace(prize))
            throw new ArgumentException("O prêmio da competição é obrigatório");
        
        if(userId <= 0)
            throw new ArgumentException("O usuário é obrigatório");
        
        var userExists = await repository.UserExists(userId);
        
        if(!userExists)
            throw new ArgumentException("O usuário não existe");
        
        if(start == default)
            throw new ArgumentException("A data de início da competição é obrigatória");
        
        if(end == default)
            throw new ArgumentException("A data de término da competição é obrigatória");
        
        if(start < DateTime.Now)
            throw new ArgumentException("A data de início da competição não pode ser menor que a data atual");
        
        if(end < DateTime.Now)
            throw new ArgumentException("A data de término da competição não pode ser menor que a data atual");
        
        if(start > end)
            throw new ArgumentException("A data de término da competição não pode ser menor que a data de início");
        
        var competition = new Competition
        {
            Name = name,
            Description = description,
            Prize = prize,
            UserId = userId,
            Start = start,
            End = end
        };

        await repository.Create(competition);
    }
}