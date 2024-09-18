using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Teams;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Teams;

public class CreateTeamServiceTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<ITeamRepository> _repository = new();
    
    [Fact]
    public async Task CreateTeamService_Create_WithValidData()
    {
        var service = new CreateTeamService(_repository.Object);

        var usersIds = _fixture.CreateMany<int>().ToList();
        
        await service.Create("Time", "http:xyz.com/image.jpg", "TM", usersIds);
        
        _repository.Verify(x => x.Create("Time", "http:xyz.com/image.jpg", "TM", It.IsAny<List<User>>()), Times.Once);
    }
    
    [Fact]
    public async Task CreateTeamService_Create_WithEmptyName()
    {
        var service = new CreateTeamService(_repository.Object);
        
        var usersIds = _fixture.CreateMany<int>().ToList();
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.Create("", "http:xyz.com/image.jpg", "TM", usersIds));
        
        Assert.Equal("Nome do time é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task CreateTeamService_Create_WithEmptyShortName()
    {
        var service = new CreateTeamService(_repository.Object);
        
        var usersIds = _fixture.CreateMany<int>().ToList();
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.Create("Time", "http:xyz.com/image.jpg", "", usersIds));
        
        Assert.Equal("Nome curto do time é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task CreateTeamService_Create_WithEmptyImageUrl()
    {
        var service = new CreateTeamService(_repository.Object);
        
        var usersIds = _fixture.CreateMany<int>().ToList();
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.Create("Time", "", "TM", usersIds));
        
        Assert.Equal("A url da imagem é obrigatória", exception.Message);
    }
    
    [Fact]
    public async Task CreateTeamService_Create_WithEmptyMembers()
    {
        var service = new CreateTeamService(_repository.Object);
        
        var usersIds = new List<int>();
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.Create("Time", "http:xyz.com/image.jpg", "TM", usersIds));
        
        Assert.Equal("Membros do time são obrigatórios", exception.Message);
    }
}