using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Competitions;

public class EditCompetitionServiceTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<ICompetitionRepository> _repository = new();
    
    [Fact]
    public async Task EditCompetitionService_EditCompetition_WithSuccess()
    {
        // Arrange
        _repository.Setup(x => x.Find(It.IsAny<int>())).ReturnsAsync(_fixture.Create<Competition>());
        
        var service = new EditCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = DateTime.Now.AddDays(1);
        var end = DateTime.Now.AddDays(2);
        const int competitionId = 1;
        
        // Act
        await service.EditCompetition(competitionId, name, description, prize, start, end);
        
        // Assert
        _repository.Verify(x => x.Edit(It.IsAny<Competition>()), Times.Once);
    }
    
    [Fact]
    public async Task EditCompetitionService_EditCompetition_WithEmptyName()
    {
        // Arrange
        var service = new EditCompetitionService(_repository.Object);
        var name = string.Empty;
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = _fixture.Create<DateTime>();
        var end = _fixture.Create<DateTime>();
        const int competitionId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.EditCompetition(competitionId, name, description, prize, start, end));
        
        // Assert
        Assert.Equal("O nome da competição é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task EditCompetitionService_EditCompetition_WithEmptyDescription()
    {
        // Arrange
        var service = new EditCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = string.Empty;
        var prize = _fixture.Create<string>();
        var start = _fixture.Create<DateTime>();
        var end = _fixture.Create<DateTime>();
        const int competitionId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.EditCompetition(competitionId, name, description, prize, start, end));
        
        // Assert
        Assert.Equal("A descrição da competição é obrigatória", exception.Message);
    }
    
    [Fact]
    public async Task EditCompetitionService_EditCompetition_WithEmptyPrize()
    {
        // Arrange
        var service = new EditCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = string.Empty;
        var start = _fixture.Create<DateTime>();
        var end = _fixture.Create<DateTime>();
        const int competitionId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.EditCompetition(competitionId, name, description, prize, start, end));
        
        // Assert
        Assert.Equal("O prêmio da competição é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task EditCompetitionService_EditCompetition_WithEmptyStart()
    {
        // Arrange
        var service = new EditCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = default(DateTime);
        var end = _fixture.Create<DateTime>();
        const int competitionId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.EditCompetition(competitionId, name, description, prize, start, end));
        
        // Assert
        Assert.Equal("A data de início da competição é obrigatória", exception.Message);
    }
    
    [Fact]
    public async Task EditCompetitionService_EditCompetition_WithEmptyEnd()
    {
        // Arrange
        var service = new EditCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = _fixture.Create<DateTime>();
        var end = default(DateTime);
        const int competitionId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.EditCompetition(competitionId, name, description, prize, start, end));
        
        // Assert
        Assert.Equal("A data de término da competição é obrigatória", exception.Message);
    }
    
    [Fact]
    public async Task EditCompetitionService_EditCompetition_WithStartLessThanNow()
    {
        // Arrange
        var service = new EditCompetitionService(_repository.Object);
        var name = _fixture.Create<string>();
        var description = _fixture.Create<string>();
        var prize = _fixture.Create<string>();
        var start = DateTime.Now.AddDays(-1);
        var end = _fixture.Create<DateTime>();
        const int competitionId = 1;
        
        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => service.EditCompetition(competitionId, name, description, prize, start, end));
        
        // Assert
        Assert.Equal("A data de início da competição não pode ser menor que a data atual", exception.Message);
    }
}