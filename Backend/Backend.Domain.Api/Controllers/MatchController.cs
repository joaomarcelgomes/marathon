using Backend.Domain.Service.Services.Matches.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Domain.Api.Controllers;

[ApiController]
[Route("match")]
public class MatchController : ControllerBase
{
    [HttpPost("create/{competitionId:int}")]
    public async Task<IActionResult> Create([FromServices] ICreateMatchService createMatchService, int competitionId)
    {
        try
        {
            var result = await createMatchService.Create(competitionId);
            return Ok(result);
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest(new { success = false, message = "Não foi possível criar as partidas" });
        }
    }
    
    [HttpPost("define-winner/{teamId:int}/{matchId:int}")]
    public async Task<IActionResult> DefineWinner([FromServices] IDefineWinnerMatchService defineWinnerMatchService, int teamId, int matchId)
    {
        try
        {
            await defineWinnerMatchService.DefineWinner(teamId, matchId);
            return Ok(new { success = true, message = "Vencedor definido com sucesso" });
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest(new { success = false, message = "Não foi possível definir o vencedor" });
        }
    }
    
    [HttpGet("all/{competitionId:int}")]
    public async Task<IActionResult> ReturnMatches([FromServices] IGetMatchService getMatchService, int competitionId)
    {
        try
        {
            var result = await getMatchService.GetMatches(competitionId);
            return Ok(result);
        }
        catch (Exception ex) when (ex is ArgumentException or InvalidOperationException)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest(new { success = false, message = "Não foi possível retornar as partidas" });
        }
    }
}