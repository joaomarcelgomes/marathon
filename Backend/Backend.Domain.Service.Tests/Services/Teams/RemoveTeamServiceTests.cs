using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services;
using Backend.Domain.Service.Services.Teams;
using Moq;

namespace Backend.Domain.Service.Tests.Services;

public class RemoveTeamServiceTests
{
    private readonly Mock<ITeamRepository> _repository = new();
    
    [Fact]
    public async Task RemoveTeamService_Remove_WithValidData()
    {
        var service = new RemoveTeamService(_repository.Object);
        
        await service.RemoveTeam(1);
        
        _repository.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
    }
}