using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Competitions;

public class CreateCompetitionServiceTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<ICompetitionRepository> _repository = new();
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithSuccess()
    {
        // Arrange
        _repository.Setup(x => x.UserExists(It.IsAny<int>())).ReturnsAsync(true);
        
        var service = new CreateCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = DateTime.Now.AddDays(1);
        var end = DateTime.Now.AddDays(2);
        const int userId = 1;
        
        // Act
        await service.Create(name, description, prize, userId, start, end);
        
        // Assert
        _repository.Verify(x => x.Create(It.IsAny<Competition>()), Times.Once);
    }
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithEmptyName()
    {
        // Arrange
        var service = new CreateCompetitionService(_repository.Object);
        var name = string.Empty;
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = _fixture.Create<DateTime>();
        var end = _fixture.Create<DateTime>();
        const int userId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(name, description, prize, userId, start, end));
        
        // Assert
        Assert.Equal("O nome da competição é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithEmptyDescription()
    {
        // Arrange
        var service = new CreateCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = string.Empty;
        var prize = _fixture.Create<string>();
        var start = _fixture.Create<DateTime>();
        var end = _fixture.Create<DateTime>();
        const int userId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(name, description, prize, userId, start, end));
        
        // Assert
        Assert.Equal("A descrição da competição é obrigatória", exception.Message);
    }
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithEmptyPrize()
    {
        // Arrange
        var service = new CreateCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = string.Empty;
        var start = _fixture.Create<DateTime>();
        var end = _fixture.Create<DateTime>();
        const int userId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(name, description, prize, userId, start, end));
        
        // Assert
        Assert.Equal("O prêmio da competição é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithDefaultStart()
    {
        // Arrange
        _repository.Setup(x => x.UserExists(It.IsAny<int>())).ReturnsAsync(true);
        
        var service = new CreateCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        DateTime start = default;
        var end = _fixture.Create<DateTime>();
        const int userId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(name, description, prize, userId, start, end));
        
        // Assert
        Assert.Equal("A data de início da competição é obrigatória", exception.Message);
    }
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithDefaultEnd()
    {
        // Arrange
        _repository.Setup(x => x.UserExists(It.IsAny<int>())).ReturnsAsync(true);
        
        var service = new CreateCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = _fixture.Create<DateTime>();
        DateTime end = default;
        const int userId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(name, description, prize, userId, start, end));
        
        // Assert
        Assert.Equal("A data de término da competição é obrigatória", exception.Message);
    }
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithStartLessThanNow()
    {
        // Arrange
        _repository.Setup(x => x.UserExists(It.IsAny<int>())).ReturnsAsync(true);
        
        var service = new CreateCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = DateTime.Now.AddDays(-1);
        var end = _fixture.Create<DateTime>();
        const int userId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(name, description, prize, userId, start, end));
        
        // Assert
        Assert.Equal("A data de início da competição não pode ser menor que a data atual", exception.Message);
    }
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithEndLessThanNow()
    {
        // Arrange
        _repository.Setup(x => x.UserExists(It.IsAny<int>())).ReturnsAsync(true);
        
        var service = new CreateCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = DateTime.Now.AddDays(1);
        var end = DateTime.Now.AddDays(-1);
        const int userId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(name, description, prize, userId, start, end));
        
        // Assert
        Assert.Equal("A data de término da competição não pode ser menor que a data atual", exception.Message);
    }
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithUserIdLessThanZero()
    {
        // Arrange
        var service = new CreateCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = _fixture.Create<DateTime>();
        var end = _fixture.Create<DateTime>();
        const int userId = -1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(name, description, prize, userId, start, end));
        
        // Assert
        Assert.Equal("O usuário é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task CreateCompetitionService_CreateCompetition_WithUserNotExists()
    {
        // Arrange
        _repository.Setup(x => x.UserExists(It.IsAny<int>())).ReturnsAsync(false);
        
        var service = new CreateCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = _fixture.Create<DateTime>();
        var end = _fixture.Create<DateTime>();
        const int userId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.Create(name, description, prize, userId, start, end));
        
        // Assert
        Assert.Equal("O usuário não existe", exception.Message);
    }
}