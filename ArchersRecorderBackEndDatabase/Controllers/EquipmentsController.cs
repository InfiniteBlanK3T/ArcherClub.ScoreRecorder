using ArchersRecorderBackEndDatabase.Models;
using ArchersRecorderBackEndDatabase.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ArchersRecorderBackEndDatabase.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentsController : ControllerBase
{
    private readonly IEquipmentRepository _repository;

    public EquipmentsController(IEquipmentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipments>>> Get()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{equipmentName}")]
    public async Task<ActionResult<Equipments>> Get(string equipmentName)
    {
        var equipment = await _repository.GetByNameAsync(equipmentName);

        if (equipment == null)
        {
            return NotFound();
        }

        return Ok(equipment);
    }
}
