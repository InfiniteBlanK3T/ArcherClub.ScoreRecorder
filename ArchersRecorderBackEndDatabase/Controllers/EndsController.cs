using ArchersRecorderBackEndDatabase.Models;
using ArchersRecorderBackEndDatabase.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArchersRecorderBackEndDatabase.Controllers;

public class EndsController : GenericController<Ends>
{
    private readonly IEndsRepository _endsRepository;

    public EndsController(IEndsRepository endsRepository) : base(endsRepository)
    {
        _endsRepository = endsRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Ends>> PostEnds(Ends ends)
    {
        await _endsRepository.AddAsync(ends);
        return CreatedAtAction("Get", new { id = ends.EndId }, ends);
    }
}
