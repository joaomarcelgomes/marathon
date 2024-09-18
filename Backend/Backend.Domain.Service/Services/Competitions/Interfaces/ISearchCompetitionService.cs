using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services.Competitions.Interfaces;

public interface ISearchCompetitionService
{
    public Task<List<Competition>> SearchCompetitions(int userId);
}