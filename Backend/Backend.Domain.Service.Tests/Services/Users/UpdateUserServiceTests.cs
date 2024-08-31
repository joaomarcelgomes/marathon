using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Users;

public class UpdateUserServiceTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<IUserRepository> _repository = new();
    
    [Fact]
    public async Task UpdateUserService_UpdateUser_UserUpdated()
    {
        // Arrange
        var user = _fixture.Create<User>();
        
        _repository.Setup(x => x.GetUser(It.IsAny<int>())).ReturnsAsync(user);
        
        var service = new UpdateUserService(_repository.Object);
        
        // Act
        await service.Update(user.Id, "John Doe", "https://domain.com/avatar.jpg", "john.doe@domain.com", "@Admin12345");
        
        // Assert
        _repository.Verify(x => x.Update(user), Times.Once);
    }
    
    [Fact]
    public async Task UpdateUserService_UpdateUser_UserNotFound()
    {
        // Arrange
        _repository.Setup(x => x.GetUser(It.IsAny<int>()));
        
        var service = new UpdateUserService(_repository.Object);
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => 
            service.Update(1, "John Doe", "https://domain.com/avatar.jpg", "john.doe@domain.com", "@Admin12345"));
        
        // Assert
        Assert.Equal("Usuário não encontrado", exception.Message);
        
        _repository.Verify(x => x.Update(It.IsAny<User>()), Times.Never);
    }
}