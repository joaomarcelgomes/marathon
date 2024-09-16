using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions.Interfaces;

namespace Backend.Domain.Service.Services.Competitions;

public class EditCompetitionService(ICompetitionRepository repository) : IEditCompetitionService
{
    public async Task EditCompetition(int competitionId, string name, string description, string prize, DateTime start, DateTime end)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("O nome da competição é obrigatório");
        
        if(string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("A descrição da competição é obrigatória");
        
        if(string.IsNullOrWhiteSpace(prize))
            throw new ArgumentException("O prêmio da competição é obrigatório");
        
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
        
        var competition = await repository.Find(competitionId);
        
        if(competition == null)
            throw new ArgumentException("A competição não existe");
        
        competition.Name = name;
        competition.Description = description;
        competition.Prize = prize;
        competition.Start = start;
        competition.End = end;
        
        await repository.Edit(competition);
    }
}