using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services;
using Moq;

namespace Backend.Domain.Service.Tests.Services;

public class LoginUserServiceTests
{
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
        _repository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(false);
        
        var service = new LoginUserService(_repository.Object);

        var result = await service.Login(email, password);
        
        Assert.False(result);
    }
    
    [Theory]
    [InlineData("user@domain.com", "@Admin1234")]
    public async Task Login_WithValidEmailAndPassword_ShouldReturnUser(string email, string password)
    {
        _repository.Setup(x => x.EmailExists(It.IsAny<string>())).ReturnsAsync(true);
        _repository.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(true);
        
        var service = new LoginUserService(_repository.Object);
        
        var user = await service.Login(email, password);
        
        Assert.True(user);
    }
}