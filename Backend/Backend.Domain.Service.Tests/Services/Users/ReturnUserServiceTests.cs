using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Users;

public class ReturnUserServiceTests
{
    private const int UserId = 1;
    
    private readonly Fixture _fixture = new();
    private readonly Mock<IUserRepository> _repository = new();
    
    [Fact]
    public async Task ReturnUser_WhenEmailIsInvalid_ThrowsArgumentException()
    {
        var service = new ReturnUserService(_repository.Object);

        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.ReturnUser(-1));
        
        Assert.Equal("Usuário informado é inválido", exception.Message);
    }

    [Fact]
    public async Task ReturnUser_WhenUserNotFound_ThrowsInvalidOperationException()
    {
        _repository.Setup(x => x.GetUser(It.IsAny<int>()));
        
        var service = new ReturnUserService(_repository.Object);

        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => service.ReturnUser(UserId));
        
        Assert.Equal("Usuário não encontrado", exception.Message);
    }
    
    [Fact]
    public async Task ReturnUser_WhenUserFound_ReturnsReturnUserModel()
    {
        var user = _fixture.Create<User>();
        
        _repository.Setup(x => x.GetUser(It.IsAny<int>())).ReturnsAsync(user);
        
        var service = new ReturnUserService(_repository.Object);

        var result = await service.ReturnUser(UserId);
        
        Assert.Equal(user.Id, result.Id);
        Assert.Equal(user.Name, result.Name);
        Assert.Equal(user.Avatar, result.Avatar);
        Assert.Equal(user.Email, result.Email);
    }
}