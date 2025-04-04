using Microsoft.AspNetCore.Mvc;
using TerminationSystem.Services;

namespace TerminationSystem.Controllers;

[ApiController]
[Route("/api/termination")]
public class TerminationController : ControllerBase
{
    private readonly TerminationService _terminationService;
    private readonly ILogger<TerminationController> _logger;

    public TerminationController(TerminationService terminationService, ILogger<TerminationController> logger)
    {
        _terminationService = terminationService;
        _logger = logger;
    }
    
    [HttpGet("reasons", Name = "GetTerminationReasonsAsync")]
    public async Task<IActionResult> GetTerminationReasonsAsync()
    {
        try
        {
            var result = await _terminationService.GetAllTerminationReasonsAsync();

            if (result.Count == 0)
            {
                _logger.LogInformation("No termination records found.");
                return Ok(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while processing the GET request.");
            return BadRequest("An error occurred while fetching data.");
        }
    }

}