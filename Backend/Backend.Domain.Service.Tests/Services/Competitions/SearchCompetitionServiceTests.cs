using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Competitions;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Competitions;

public class SearchCompetitionServiceTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<ICompetitionRepository> _repository = new();
    
    [Fact]
    public async Task SearchCompetitions_WhenUserIdIsInvalid_ThrowsArgumentException()
    {
        // Arrange
        var service = new SearchCompetitionService(_repository.Object);
        
        // Act
        async Task Act() => await service.SearchCompetitions(0);
        
        // Assert
        await Assert.ThrowsAsync<ArgumentException>(Act);
    }
    
    [Fact]
    public async Task SearchCompetitions_WhenUserIdIsValid_ReturnsCompetitions()
    {
        // Arrange
        const int userId = 1;
        var competitions = _fixture.CreateMany<Competition>().ToList();
        
        _repository.Setup(x => x.All(userId)).ReturnsAsync(competitions);
        
        var service = new SearchCompetitionService(_repository.Object);
        
        // Act
        var result = await service.SearchCompetitions(userId);
        
        // Assert
        Assert.Equal(competitions, result);
    }
}