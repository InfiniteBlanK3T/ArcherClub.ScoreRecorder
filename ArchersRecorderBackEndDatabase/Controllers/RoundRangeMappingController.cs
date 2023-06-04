using ArchersRecorderBackEndDatabase.Models;
using ArchersRecorderBackEndDatabase.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArchersRecorderBackEndDatabase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoundRangeMappingController : ControllerBase
{
    private readonly IRoundRangeMappingRepository _repository;

    public RoundRangeMappingController(IRoundRangeMappingRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoundRangeMapping>>> Get()
    {
        return Ok(await _repository.GetAllAsync());
    }
    [HttpGet("{roundId}")]
    public async Task<ActionResult<RoundRangeMapping>> GetByIdAsync(int roundId)
    {
        var roundrangemapping = await _repository.GetByIdAsync(roundId);
        if (roundrangemapping == null)
        {
            return NotFound();
        }
        return Ok(roundrangemapping);
    }
    [HttpGet("{roundId}/{rangeId}")]
    public async Task<ActionResult<RoundRangeMapping>> GetBySpecificIdAsync(int roundId, int rangeId)
    {
        var roundrangemapping = await _repository.GetBySpecificIdAsync(roundId, rangeId);
         if (roundrangemapping == null)
        {
            return NotFound();
        }
        return Ok(roundrangemapping);
    }
}
