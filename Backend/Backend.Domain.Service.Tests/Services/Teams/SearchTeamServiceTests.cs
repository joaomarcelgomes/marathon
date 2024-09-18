using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Teams;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Teams;

public class SearchTeamServiceTests
{
    private readonly Mock<ITeamRepository> _repository = new();
    
    [Fact]
    public async Task All_WithNoParameter_ShouldReturnAllTeams()
    {
        var service = new SearchTeamService(_repository.Object);
        
        await service.All();
        
        _repository.Verify(x => x.All(), Times.Once);
    }
    
    [Fact]
    public async Task Search_WithNoParameter_ShouldReturnAllTeams()
    {
        var service = new SearchTeamService(_repository.Object);
        
        await service.Search("");
        
        _repository.Verify(x => x.All(), Times.Once);
    }
    
    [Fact]
    public async Task Search_WithParameter_ShouldReturnTeams()
    {
        var service = new SearchTeamService(_repository.Object);
        
        await service.Search("text");
        
        _repository.Verify(x => x.Search("text"), Times.Once);
    }
    
    [Fact]
    public async Task Find_WithInvalidId_ShouldThrowArgumentException()
    {
        var service = new SearchTeamService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            await service.Find(0));
        
        Assert.Equal("O id do time precisa ser maior que zero", exception.Message);
    }
    
    [Fact]
    public async Task Find_WithValidId_ShouldReturnTeam()
    {
        var service = new SearchTeamService(_repository.Object);
        
        await service.Find(1);
        
        _repository.Verify(x => x.Find(1), Times.Once);
    }
}