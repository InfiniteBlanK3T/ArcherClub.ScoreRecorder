using ArchersRecorderBackEndDatabase.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArchersRecorderBackEndDatabase.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GenericController<T> : ControllerBase where T : class
{
    private readonly IRepository<T> _repository;

    public GenericController(IRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> Get()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<T>> Get(int id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }
}
