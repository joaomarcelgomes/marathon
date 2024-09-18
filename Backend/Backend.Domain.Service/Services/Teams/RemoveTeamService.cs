using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Teams.Interfaces;

namespace Backend.Domain.Service.Services.Teams;

public class RemoveTeamService(ITeamRepository repository) : IRemoveTeamService
{
    public async Task RemoveTeam(int id) => await repository.Delete(id);
}