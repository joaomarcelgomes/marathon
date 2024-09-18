using Backend.Domain.Service.Models.Responses.Matches;
using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services.Matches.Interfaces;

public interface ICreateMatchService
{
    public Task<ReturnMatches> Create(int competitionId);
}