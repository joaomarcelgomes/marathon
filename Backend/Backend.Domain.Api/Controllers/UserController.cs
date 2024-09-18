using Backend.Domain.Api.Models.Requests.Users;
using Backend.Domain.Auth.Auth;
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
    
    [HttpGet("profile")]
    public async Task<ActionResult> ReturnUser([FromServices] IReturnUserService userService, [FromHeader(Name = "Authorization")] string authorization)
    {
        try
        {
            var auth = new TokenService();
            
            var token = authorization.Split(" ").Last();
            
            var id = auth.GetUserId(token);
            
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
    
    [HttpGet("all")]
    public async Task<ActionResult> All([FromServices] IGetAllUsersService userService)
    {
        try
        {
            var users = await userService.All();
            
            return Ok(new { success = true, data = users });
        }
        catch (Exception)
        {
            return BadRequest(new { success = false, message = "Não foi possível buscar os usuários" });
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