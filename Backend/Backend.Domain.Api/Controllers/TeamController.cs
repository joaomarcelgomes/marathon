using Backend.Domain.Api.Models.Requests;
using Backend.Domain.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers;

[ApiController]
[Route("team")]
public class TeamController : ControllerBase
{
    [HttpGet("all")]
    public async Task<ActionResult> All([FromServices] ISearchTeamService teamService)
    {
        try
        {
            var teams = await teamService.All();
            
            if(teams.Count == 0)
                return NotFound(new { success = false, message = "Nenhum time encontrado", data = teams });
            
            return Ok(new { success = true, message = "Lista de times", data = teams });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpGet("search")]
    public async Task<ActionResult> Search([FromServices] ISearchTeamService teamService, [FromQuery] string q)
    {
        try
        {
            var teams = await teamService.Search(q);
            
            if(teams.Count == 0)
                return NotFound(new { success = false, message = "Nenhum time encontrado", data = teams });
            
            return Ok(new { success = true, message = "Lista de times", data = teams });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpGet("find/:id")]
    public async Task<ActionResult> Find([FromServices] ISearchTeamService teamService, int id)
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
    public async Task<ActionResult> Create([FromServices] ICreateTeamService teamService, [FromBody] TeamCreateRequest request)
    {
        try
        {
            await teamService.Create(request.Name, request.ImageUrl, request.ShortName, request.Members);
            
            return Ok(new { success = true, message = "Time criado com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
}