using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Repositories;

public interface ICompetitionRepository
{
    public Task<bool> UserExists(int userId);
    public Task Create(Competition competition);
}