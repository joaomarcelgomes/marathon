using Backend.Domain.Api.Models.Requests.Teams;
using Backend.Domain.Service.Services.Competitions.Interfaces;
using Backend.Domain.Service.Services.Teams.Interfaces;
using Backend.Domain.Service.Services.Users.Interfaces;
using Backend.Infra.EntityLibrary.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers;

[ApiController]
[Route("team")]
public class TeamController : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult> All([FromServices] ISearchTeamService teamService, [FromHeader(Name = "Authorization")] string authorization)
    {
        try
        {
            var teams = await teamService.All();
            
            if(teams.Count == 0)
                return Ok(new { success = false, message = "Nenhum time encontrado", data = Array.Empty<Team>() });
            
            return Ok(new { success = true, message = "Lista de times", data = teams });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message, data = Array.Empty<Team>() });
        }
    }
    
    [HttpGet("search")]
    public async Task<ActionResult> Search([FromServices] ISearchTeamService teamService, [FromHeader(Name = "Authorization")] string authorization, [FromQuery] string q)
    {
        try
        {
            var teams = await teamService.Search(q);
            
            if(teams.Count == 0)
                return Ok(new { success = false, message = "Nenhum time encontrado", data = teams });
            
            return Ok(new { success = true, message = "Lista de times", data = teams });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpGet("find/{id:int}")]
    public async Task<ActionResult> Find([FromServices] ISearchTeamService teamService, [FromHeader(Name = "Authorization")] string authorization, int id)
    {
        try
        {
            var team = await teamService.Find(id);
            
            return Ok(new { success = true, message = "Time encontrado", data = team });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpPost("create")]
    public async Task<ActionResult> Create([FromServices] ICreateTeamService teamService, [FromHeader(Name = "Authorization")] string authorization, [FromBody] TeamCreateRequest request)
    {
        try
        {
            await teamService.Create(request.Name, request.ImageUrl, request.ShortName, request.UsersIds);
            
            return Ok(new { success = true, message = "Time criado com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpPut("edit/{id:int}")]
    public async Task<ActionResult> Edit([FromServices] IEditTeamService teamService, [FromHeader(Name = "Authorization")] string authorization, int id, [FromBody] TeamCreateRequest request)
    {
        try
        {
            await teamService.EditTeam(id, request.Name, request.ImageUrl, request.ShortName);
            
            return Ok(new { success = true, message = "Time editado com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpDelete("remove/{id:int}")]
    public async Task<ActionResult> Remove([FromServices] IRemoveTeamService teamService, [FromHeader(Name = "Authorization")] string authorization, int id)
    {
        try
        {
            await teamService.RemoveTeam(id);
            
            return Ok(new { success = true, message = "Time removido com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpPost("{teamId:int}/user")]
    public async Task<ActionResult> InsertUser([FromServices] IInsertUserInTeamService teamService, [FromHeader(Name = "Authorization")] string authorization, int teamId, [FromBody] InsertUsersInTeamRequest request)
    {
        try
        {
            await teamService.InsertUserInTeam(teamId, request.UsersIds);
            
            return Ok(new { success = true, message = "Usuários inseridos no time com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpDelete("{teamId:int}/user/{userId:int}")]
    public async Task<ActionResult> RemoveUser([FromServices] IRemoveUserOfTeamService teamService, [FromHeader(Name = "Authorization")] string authorization, int teamId, int userId)
    {
        try
        {
            await teamService.RemoveUserOfTeam(teamId, userId);
            
            return Ok(new { success = true, message = "Usuários removido do time com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
}