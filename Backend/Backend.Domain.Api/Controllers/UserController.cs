using Backend.Domain.Api.Models;
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
}