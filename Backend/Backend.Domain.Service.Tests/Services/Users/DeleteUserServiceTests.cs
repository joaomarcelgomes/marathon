using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Users;

public class DeleteUserServiceTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<IUserRepository> _repository = new();
    
    [Fact]
    public async Task DeleteUserService_DeleteUser_UserDeleted()
    {
        // Arrange
        var user = _fixture.Create<User>();
        _repository.Setup(x => x.GetUser(It.IsAny<int>())).ReturnsAsync(user);
        
        var service = new DeleteUserService(_repository.Object);
        
        // Act
        await service.Delete(user.Id);
        
        // Assert
        _repository.Verify(x => x.Delete(user), Times.Once);
    }
    
    [Fact]
    public async Task DeleteUserService_DeleteUser_UserNotFound()
    {
        // Arrange
        _repository.Setup(x => x.GetUser(It.IsAny<int>()));
        
        var service = new DeleteUserService(_repository.Object);
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Delete(_fixture.Create<int>()));
        
        // Assert
        Assert.Equal("Usuário não encontrado", exception.Message);
        
        _repository.Verify(x => x.Delete(It.IsAny<User>()), Times.Never);
    }
}