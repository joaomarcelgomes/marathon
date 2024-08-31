using Backend.Domain.Service.Repositories;
using Backend.Domain.Service.Services.Users;
using Moq;

namespace Backend.Domain.Service.Tests.Services.Users;

public class CreateUserServiceTests
{
    private const string Name = "John Mach";
    private const string Email = "john.mach@domain.com";
    private const string Avatar = "https://domain.com/image.jpg";
    private const string Password = "@Admin1234";
    
    private readonly Mock<IUserRepository> _repository = new();
    
    [Theory]
    [InlineData("")]
    [InlineData("Bam")]
    public async Task Create_WithInvalidName_ShouldThrowArgumentException(string name)
    {
        var service = new CreateUserService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            await service.Create(name, Avatar, Email, Password));
        
        Assert.Equal("O nome do usuário precisa ter pelo menos 4 caracteres", exception.Message);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData("email")]
    public async Task Create_WithInvalidEmail_ShouldThrowArgumentException(string email)
    {
        var service = new CreateUserService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            await service.Create(Name, Avatar, email, Password));
        
        Assert.Equal("O e-mail informado é inválido", exception.Message);
    }

    [Theory]
    [InlineData("")]
    [InlineData("pass")]
    public async Task Create_WithInvalidPassword_ShouldThrowArgumentException(string password)
    {
        var service = new CreateUserService(_repository.Object);

        var exception = await Assert.ThrowsAsync<ArgumentException>(async () => 
            await service.Create(Name, Avatar, Email, password));
        
        Assert.Equal("A senha precisa ter pelo menos 8 caracteres", exception.Message);
    }
    
    [Fact]
    public async Task Create_WithExistingEmail_ShouldThrowInvalidOperationException()
    {
        _repository.Setup(x => x.EmailExists(It.IsAny<string>())).ReturnsAsync(true);
        
        var service = new CreateUserService(_repository.Object);
        
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () => 
            await service.Create(Name, Avatar, Email, Password));
        
        Assert.Equal("O e-mail informado já está em uso", exception.Message);
    }

    [Theory]
    [InlineData("")]
    public async Task Create_WithInvalidAvatar_ShouldThrowArgumentException(string avatar)
    {
        var service = new CreateUserService(_repository.Object);

        var exception = await Assert.ThrowsAsync<ArgumentException>(async () =>
            await service.Create("John Mach", avatar, "", ""));
        
        Assert.Equal("O avatar é obrigatório", exception.Message);
    }

    [Fact]
    public async Task Create_WithValidData_ShouldCallRepository()
    {
        _repository.Setup(x => x.EmailExists(It.IsAny<string>())).ReturnsAsync(false);
        
        var service = new CreateUserService(_repository.Object);
        
        await service.Create(Name, Avatar, Email, Password);
        
        _repository.Verify(x => x.Create(Name, Avatar, Email, Password), Times.Once);
    }
}