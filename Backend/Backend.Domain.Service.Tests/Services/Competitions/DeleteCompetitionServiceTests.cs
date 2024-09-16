using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Competitions;

public class DeleteCompetitionServiceTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<ICompetitionRepository> _repository = new();
    
    [Fact]
    public async Task DeleteCompetition_WithValidId_ShouldDeleteCompetition()
    {
        // Arrange
        var competitionId = _fixture.Create<int>();
        var competition = _fixture.Create<Competition>();
        
        _repository.Setup(x => x.Find(competitionId)).ReturnsAsync(competition);
        
        var service = new DeleteCompetitionService(_repository.Object);
        
        // Act
        await service.DeleteCompetition(competitionId);
        
        // Assert
        _repository.Verify(x => x.Delete(competition), Times.Once);
    }
    
    [Fact]
    public async Task DeleteCompetition_WithInvalidId_ShouldThrowArgumentException()
    {
        // Arrange
        var competitionId = 0;
        
        var service = new DeleteCompetitionService(_repository.Object);
        
        // Act
        async Task Act() => await service.DeleteCompetition(competitionId);
        
        // Assert
        await Assert.ThrowsAsync<ArgumentException>(Act);
    }
    
    [Fact]
    public async Task DeleteCompetition_WithNonExistentCompetition_ShouldThrowArgumentException()
    {
        // Arrange
        var competitionId = _fixture.Create<int>();
        
        _repository.Setup(x => x.Find(competitionId));
        
        var service = new DeleteCompetitionService(_repository.Object);
        
        // Act
        async Task Act() => await service.DeleteCompetition(competitionId);
        
        // Assert
        await Assert.ThrowsAsync<ArgumentException>(Act);
    }
}