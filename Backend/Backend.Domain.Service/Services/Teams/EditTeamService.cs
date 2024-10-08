﻿using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Teams.Interfaces;

namespace Backend.Domain.Service.Services.Teams;

public class EditTeamService(ITeamRepository repository) : IEditTeamService
{
    public async Task EditTeam(int id, string name, string shortName, string urlImage)
    {
        if(string.IsNullOrEmpty(name))
            throw new Exception("Nome do time é obrigatório");
        
        if(string.IsNullOrEmpty(urlImage))
            throw new Exception("A url da imagem é obrigatória");
        
        if(string.IsNullOrEmpty(shortName))
            throw new Exception("Nome curto do time é obrigatório");
        
        var team = await repository.Find(id);
        
        if(team == null)
            throw new Exception("Time não encontrado");
        
        team.Name = name;
        team.ShortName = shortName;
        team.ImageUrl = urlImage;
        
        await repository.Edit(team);
    }
}