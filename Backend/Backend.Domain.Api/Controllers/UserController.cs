using Backend.Domain.Api.Models.Requests;
using Backend.Domain.Service.Services.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost("create")]
    public async Task<ActionResult> Create([FromServices] ICreateUserService userService, [FromBody] UserCreateRequest request)
    {
        try
        {
            await userService.Create(request.Name, request.Avatar, request.Email, request.Password);
            
            return Ok(new { success = true, message = "Usuário criado com sucesso" });
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest(new { success = false, message = "Não foi possível criar o usuário" });
        }
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromServices] ILoginUserService userService, [FromBody] UserLoginRequest request)
    {
        try
        {
            var user = await userService.Login(request.Email, request.Password);

            return Ok(user ? new { success = true, message = "Usuário logado com sucesso" } : new { success = false, message = "Usuário ou senha inválidos" });
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest(new { success = false, message = "Não foi possível fazer o login" });
        }
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult> ReturnUser([FromServices] IReturnUserService userService, int id)
    {
        try
        {
            var user = await userService.ReturnUser(id);

            return Ok(new { success = true, data = user });
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest(new { success = false, message = "Não foi possível buscar o usuário" });
        }
    }
}