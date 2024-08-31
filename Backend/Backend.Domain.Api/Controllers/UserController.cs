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
            var (user, token) = await userService.Create(request.Name, request.Avatar, request.Email, request.Password);
            
            return Ok(new { success = true, message = "Usuário criado com sucesso", data = new { user, token } });
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
            var (user, token) = await userService.Login(request.Email, request.Password);
            
            return Ok(new { success = true, message = "Usuário logado com sucesso", data = new {user, token} });
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
    public async Task<ActionResult> ReturnUser([FromServices] IReturnUserService userService, [FromHeader(Name = "Authorization")] string authorization, int id)
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
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete([FromServices] IDeleteUserService userService, [FromHeader(Name = "Authorization")] string authorization, int id)
    {
        try
        {
            await userService.Delete(id);
            
            return Ok(new { success = true, message = "Usuário deletado com sucesso" });
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest(new { success = false, message = "Não foi possível deletar o usuário" });
        }
    }
    
    [HttpPut]
    public async Task<ActionResult> Update([FromServices] IUpdateUserService userService, [FromHeader(Name = "Authorization")] string authorization, [FromBody] UserUpdateRequest request)
    {
        try
        {
            await userService.Update(request.Id, request.Name, request.Avatar, request.Email, request.Password);
            
            return Ok(new { success = true, message = "Usuário atualizado com sucesso" });
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest(new { success = false, message = "Não foi possível atualizar o usuário" });
        }
    }
}