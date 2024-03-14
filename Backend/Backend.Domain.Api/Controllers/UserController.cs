using Backend.Domain.Api.Models;
using Backend.Domain.Api.Models.Requests;
using Backend.Domain.Service.Services.Interfaces;
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
            await userService.Create(request.Name, request.Email, request.Password);
            
            return Ok(new { success = true, message = "Usuário criado com sucesso" });
        }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest();
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
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}