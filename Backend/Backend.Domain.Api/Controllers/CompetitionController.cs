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
            await service.Create(request.Name, request.Description, request.Prize, request.UserId, request.Start, request.End);
            
            return Ok(new { success = true, message = "Competição criada com sucesso" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { success = false, message = ex.Message });
        }
    }
}