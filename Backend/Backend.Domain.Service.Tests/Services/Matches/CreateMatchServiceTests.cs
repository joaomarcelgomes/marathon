using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Matches;
using Backend.Infra.EntityLibrary.Entities;
using Moq;
using Xunit.Abstractions;

namespace Backend.Domain.Service.Tests.Services.Matches;

public class CreateMatchServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly Fixture _fixture = new();
    private readonly Mock<IMatchRepository> _repository = new();

    public CreateMatchServiceTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _fixture.Behaviors.Remove(_fixture.Behaviors.OfType<ThrowingRecursionBehavior>().FirstOrDefault());

        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task Create_ShouldReturnQuarterFinals_WhenCompetitionHasEightTeams()
    {
        // Arrange
        var teams = _fixture.CreateMany<Team>(8);
        
        var competition = _fixture.Build<Competition>()
            .With(x => x.Teams, teams.ToList())
            .Create();
        
        //foreach (var team in competition.Teams) _testOutputHelper.WriteLine($"{team.Id}, {team.Name}");
        
        _repository.Setup(x => x.Find(It.IsAny<int>())).ReturnsAsync(competition);
        
        var service = new CreateMatchService(_repository.Object);
        
        // Act
        var matches = await service.Create(competition.Id);
        
        //foreach (var match in matches) _testOutputHelper.WriteLine($"{match.Team1Id} x {match.Team2Id}");
        
        // Assert
        Assert.NotNull(matches);
        Assert.True(matches.QuarterFinals.Any());
        Assert.False(matches.SemiFinals.Any());
        Assert.False(matches.Finals.Any());
    }
    
    [Fact]
    public async Task Create_ShouldReturnSemiFinals_WhenCompetitionHasFourTeams()
    {
        // Arrange
        var teams = _fixture.CreateMany<Team>(4);
        
        var competition = _fixture.Build<Competition>()
            .With(x => x.Teams, teams.ToList())
            .Create();
        
        //foreach (var team in competition.Teams) _testOutputHelper.WriteLine($"{team.Id}, {team.Name}");
        
        _repository.Setup(x => x.Find(It.IsAny<int>())).ReturnsAsync(competition);
        
        var service = new CreateMatchService(_repository.Object);
        
        // Act
        var matches = await service.Create(competition.Id);
        
        //foreach (var match in matches) _testOutputHelper.WriteLine($"{match.Team1Id} x {match.Team2Id}");
        
        // Assert
        Assert.NotNull(matches);
        Assert.True(matches.SemiFinals.Any());
        Assert.False(matches.Finals.Any());
        Assert.False(matches.QuarterFinals.Any());
    }
    
    [Fact]
    public async Task Create_ShouldReturnFinals_WhenCompetitionHasTwoTeams()
    {
        // Arrange
        var teams = _fixture.CreateMany<Team>(2);
        
        var competition = _fixture.Build<Competition>()
            .With(x => x.Teams, teams.ToList())
            .Create();
        
        //foreach (var team in competition.Teams) _testOutputHelper.WriteLine($"{team.Id}, {team.Name}");
        
        _repository.Setup(x => x.Find(It.IsAny<int>())).ReturnsAsync(competition);
        
        var service = new CreateMatchService(_repository.Object);
        
        // Act
        var matches = await service.Create(competition.Id);
        
        //foreach (var match in matches) _testOutputHelper.WriteLine($"{match.Team1Id} x {match.Team2Id}");
        
        // Assert
        Assert.NotNull(matches);
        Assert.True(matches.Finals.Any());
        Assert.False(matches.SemiFinals.Any());
        Assert.False(matches.QuarterFinals.Any());
    }
}