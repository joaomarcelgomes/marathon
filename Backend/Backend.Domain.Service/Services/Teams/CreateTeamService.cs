using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Teams.Interfaces;

namespace Backend.Domain.Service.Services.Teams;

public class CreateTeamService(ITeamRepository repository) : ICreateTeamService
{
    public async Task Create(string name, string urlImage, string shortName, List<int> usersIds)
    {
        if(string.IsNullOrEmpty(name))
            throw new Exception("Nome do time é obrigatório");
        
        if(string.IsNullOrEmpty(urlImage))
            throw new Exception("A url da imagem é obrigatória");
        
        if(string.IsNullOrEmpty(shortName))
            throw new Exception("Nome curto do time é obrigatório");
        
        if(usersIds.Count == 0)
            throw new Exception("Membros do time são obrigatórios");

        var users = await repository.Find(usersIds);
        
        await repository.Create(name, urlImage, shortName, users);
    }
}