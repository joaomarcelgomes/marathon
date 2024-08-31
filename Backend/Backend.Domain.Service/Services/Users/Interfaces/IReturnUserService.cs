using Backend.Domain.Service.Models.Responses;

namespace Backend.Domain.Service.Services.Users.Interfaces;

public interface IReturnUserService
{
    public Task<ReturnUserModel> ReturnUser(int id);
}