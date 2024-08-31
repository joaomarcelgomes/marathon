using Backend.Domain.Service.Models.Responses;

namespace Backend.Domain.Service.Services.Users.Interfaces;

public interface ILoginUserService
{
    public Task<(ReturnUserModel, string token)> Login(string email, string password);
}