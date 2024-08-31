using AutoFixture;
using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users;
using Backend.Infra.EntityLibrary.Entities;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Users;

public class LoginUserServiceTests
{
    private readonly Fixture _fixture = new();
    private readonly Mock<IUserRepository> _repository = new();
    
    [Theory]
    [InlineData("", "@Admin1234")]
    [InlineData("email", "@Admin1234")]
    public async Task Login_WithInvalidEmail_ShouldThrowArgumentException(string email, string password)
    {
        var service = new LoginUserService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            await service.Login(email, password));
        
        Assert.Equal("O e-mail informado é inválido", exception.Message);
    }
    
    [Theory]
    [InlineData("user@domain.com", "")]
    [InlineData("user@domain.com", "1234567")]
    public async Task Login_WithInvalidPassword_ShouldThrowArgumentException(string email, string password)
    {
        var service = new LoginUserService(_repository.Object);

        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            await service.Login(email, password));
        
        Assert.Equal("A senha precisa ter pelo menos 8 caracteres", exception.Message);
    }
    
    [Theory]
    [InlineData("user@domain.com", "@Admin1234")]
    public async Task Login_WithInvalidEmailOrPassword_ShouldThrowInvalidOperationException(string email, string password)
    {
        _repository.Setup(x => x.EmailExists(It.IsAny<string>())).ReturnsAsync(true);
        _repository.Setup(x => x.GetUser(It.IsAny<string>(), It.IsAny<string>()));
        
        var service = new LoginUserService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            await service.Login(email, password));

        Assert.Equal("Usuário não encontrado", exception.Message);
    }
    
    [Theory]
    [InlineData("user@domain.com", "@Admin1234")]
    public async Task Login_WithValidEmailAndPassword_ShouldReturnUser(string email, string password)
    {
        var user = _fixture.Create<User>();
        
        _repository.Setup(x => x.EmailExists(It.IsAny<string>())).ReturnsAsync(true);
        _repository.Setup(x => x.GetUser(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(user);
        
        var service = new LoginUserService(_repository.Object);
        
        var (model, token) = await service.Login(email, password);
        
        Assert.Equal(user.Id, model.Id);
        Assert.Equal(user.Name, model.Name);
        Assert.Equal(user.Avatar, model.Avatar);
        Assert.Equal(user.Email, model.Email);
        
        Assert.NotEmpty(token);
    }
}