using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Interfaces;

namespace Backend.Domain.Service.Services;

public class RemoveTeamService(ITeamRepository repository) : IRemoveTeamService
{
    public async Task RemoveTeam(int id) => await repository.Delete(id);
}