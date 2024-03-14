using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services;
using Moq;

namespace Backend.Domain.Service.Tests.Services;

public class CreateUserServiceTests
{
    private readonly Mock<IUserRepository> _repository = new();
    
    [Theory]
    [InlineData("", "email", "@Admin1234")]
    [InlineData("Bam", "email", "@Admin1234")]
    public async Task Create_WithInvalidName_ShouldThrowArgumentException(string name, string email, string password)
    {
        var service = new CreateUserService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            await service.Create(name, email, password));
        
        Assert.Equal("O nome do usuário precisa ter pelo menos 5 caracteres", exception.Message);
    }
    
    [Theory]
    [InlineData("John Mach", "", "@Admin1234")]
    [InlineData("John Mach", "email", "@Admin1234")]
    public async Task Create_WithInvalidEmail_ShouldThrowArgumentException(string name, string email, string password)
    {
        var service = new CreateUserService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            await service.Create(name, email, password));
        
        Assert.Equal("O e-mail informado é inválido", exception.Message);
    }

    [Theory]
    [InlineData("John Mach", "user@domain.com", "")]
    [InlineData("John Mach", "user@domain.com", "pass")]
    public async Task Create_WithInvalidPassword_ShouldThrowArgumentException(string name, string email, string password)
    {
        var service = new CreateUserService(_repository.Object);

        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            await service.Create(name, email, password));
        
        Assert.Equal("A senha precisa ter pelo menos 8 caracteres", exception.Message);
    }
    
    [Theory]
    [InlineData("John Mach", "user@domain.com", "@Admin1234")]
    public async Task Create_WithExistingEmail_ShouldThrowInvalidOperationException(string name, string email, string password)
    {
        _repository.Setup(x => x.EmailExists(It.IsAny<string>())).ReturnsAsync(true);
        
        var service = new CreateUserService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            await service.Create(name, email, password));
        
        Assert.Equal("O e-mail informado já está em uso", exception.Message);
    }
    
    [Theory]
    [InlineData("John Mach", "user@domain.com", "@Admin1234")]
    public async Task Create_WithValidData_ShouldCallRepository(string name, string email, string password)
    {
        _repository.Setup(x => x.EmailExists(It.IsAny<string>())).ReturnsAsync(false);
        
        var service = new CreateUserService(_repository.Object);
        
        await service.Create(name, email, password);
        
        _repository.Verify(x => x.Create(name, email, password), Times.Once);
    }
}