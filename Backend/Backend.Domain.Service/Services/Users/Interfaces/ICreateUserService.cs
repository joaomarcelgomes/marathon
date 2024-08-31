using Backend.Domain.Service.Models.Responses;
using Backend.Infra.EntityLibrary.Entities;

namespace Backend.Domain.Service.Services.Users.Interfaces;

public interface ICreateUserService
{
    public Task<(ReturnUserModel, string token)> Create(string name, string avatar, string email, string password);
}