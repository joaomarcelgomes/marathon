using Backend.Domain.Api.Models.Requests.Competitions;
using Backend.Domain.Service.Services.Competitions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers;

[ApiController]
[Route("competition")]
public class CompetitionController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromServices] ICreateCompetitionService service, [FromBody] CreateCompetitionRequest request)
    {
        try
        {
            await service.Create(request.Name, request.Description, request.Prize, request.UserId, request.Start, request.End, request.TeamsIds);
            
            return Ok(new { success = true, message = "Competição criada com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Edit([FromServices] IEditCompetitionService service, int id, [FromBody] EditCompetitionRequest request)
    {
        try
        {
            await service.EditCompetition(id, request.Name, request.Description, request.Prize, request.Start, request.End);
            
            return Ok(new { success = true, message = "Competição editada com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromServices] IDeleteCompetitionService service, int id)
    {
        try
        {
            await service.DeleteCompetition(id);
            
            return Ok(new { success = true, message = "Competição deletada com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> Search([FromServices] ISearchCompetitionService service, int userId)
    {
        try
        {
            var competitions = await service.SearchCompetitions(userId);
            
            return Ok(new { success = true, message = "Competições encontradas com sucesso", competitions });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpPost("{id:int}/teams")]
    public async Task<IActionResult> AddTeam([FromServices] IInsertTeamInCompetitionService service, int id, InsertTeamInCompetitionRequest teams)
    {
        try
        {
            await service.Insert(id, teams.TeamsIds);
            
            return Ok(new { success = true, message = "Equipes adicionadas com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
    
    [HttpDelete("{id:int}/team/{teamId:int}")]
    public async Task<IActionResult> RemoveTeam([FromServices] IRemoveTeamOfCompetitionService service, int id, int teamId)
    {
        try
        {
            await service.Remove(id, teamId);
            
            return Ok(new { success = true, message = "Equipe removida com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
}