using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Teams;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Teams;

public class CreateTeamServiceTests
{
    private readonly Mock<ITeamRepository> _repository = new();
    
    [Fact]
    public async Task CreateTeamService_Create_WithValidData()
    {
        var service = new CreateTeamService(_repository.Object);

        var list = new List<string> { "Membro 1", "Membro 2" };
        
        await service.Create("Time", "http:xyz.com/image.jpg", "TM", list);
        
        _repository.Verify(x => x.Create("Time", "http:xyz.com/image.jpg", "TM", "MEMBRO 1;MEMBRO 2"), Times.Once);
    }
    
    [Fact]
    public async Task CreateTeamService_Create_WithEmptyName()
    {
        var service = new CreateTeamService(_repository.Object);
        
        var list = new List<string> { "Membro 1", "Membro 2" };
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.Create("", "http:xyz.com/image.jpg", "TM", list));
        
        Assert.Equal("Nome do time é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task CreateTeamService_Create_WithEmptyShortName()
    {
        var service = new CreateTeamService(_repository.Object);
        
        var list = new List<string> { "Membro 1", "Membro 2" };
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.Create("Time", "http:xyz.com/image.jpg", "", list));
        
        Assert.Equal("Nome curto do time é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task CreateTeamService_Create_WithEmptyImageUrl()
    {
        var service = new CreateTeamService(_repository.Object);
        
        var list = new List<string> { "Membro 1", "Membro 2" };
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.Create("Time", "", "TM", list));
        
        Assert.Equal("A url da imagem é obrigatória", exception.Message);
    }
    
    [Fact]
    public async Task CreateTeamService_Create_WithEmptyMembers()
    {
        var service = new CreateTeamService(_repository.Object);
        
        var list = new List<string>();
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.Create("Time", "http:xyz.com/image.jpg", "TM", list));
        
        Assert.Equal("Membros do time são obrigatórios", exception.Message);
    }
}