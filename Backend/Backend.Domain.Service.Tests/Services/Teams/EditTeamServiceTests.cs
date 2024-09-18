using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Teams;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Teams;

public class EditTeamServiceTests
{
    private readonly Mock<ITeamRepository> _repository = new();
    
    [Fact]
    public async Task EditTeamService_Edit_WithValidData()
    {
        _repository.Setup(x => x.Find(It.IsAny<int>())).ReturnsAsync(new Team());
        
        var service = new EditTeamService(_repository.Object);

        await service.EditTeam(1, "Time", "http:xyz.com/image.jpg", "TM");
        
        _repository.Verify(x => x.Edit(It.IsAny<Team>()), Times.Once);
    }
    
    [Fact]
    public async Task EditTeamService_Edit_WithEmptyName()
    {
        var service = new EditTeamService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.EditTeam(1, "", "http:xyz.com/image.jpg", "TM"));
        
        Assert.Equal("Nome do time é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task EditTeamService_Edit_WithEmptyShortName()
    {
        var service = new EditTeamService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.EditTeam(1, "Time", "", "http:xyz.com/image.jpg"));
        
        Assert.Equal("Nome curto do time é obrigatório", exception.Message);
    }
    
    [Fact]
    public async Task EditTeamService_Edit_WithEmptyImageUrl()
    {
        var service = new EditTeamService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.EditTeam(1, "Time", "TM", ""));
        
        Assert.Equal("A url da imagem é obrigatória", exception.Message);
    }
    
    [Fact]
    public async Task EditTeamService_Edit_WithEmptyMembers()
    {
        var service = new EditTeamService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.EditTeam(1, "Time", "http:xyz.com/image.jpg", "TM"));
        
        Assert.Equal("Membros do time são obrigatórios", exception.Message);
    }
    
    [Fact]
    public async Task EditTeamService_Edit_WithEmptyTeam()
    {
        var service = new EditTeamService(_repository.Object);
        
        _repository.Setup(x => x.Find(1));
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.EditTeam(1, "Time", "http:xyz.com/image.jpg", "TM"));
        
        Assert.Equal("Time não encontrado", exception.Message);
    }
    
    [Fact]
    public async Task EditTeamService_Edit_WithEmptyTeamId()
    {
        var service = new EditTeamService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<Exception>(() => service.EditTeam(0, "Time", "http:xyz.com/image.jpg", "TM"));
        
        Assert.Equal("Time não encontrado", exception.Message);
    }
}