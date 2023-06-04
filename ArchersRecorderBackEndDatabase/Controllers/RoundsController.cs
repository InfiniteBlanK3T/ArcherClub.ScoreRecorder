using ArchersRecorderBackEndDatabase.Models;
using ArchersRecorderBackEndDatabase.Repositories;

namespace ArchersRecorderBackEndDatabase.Controllers;

public class RoundsController : GenericController<Rounds>
{
    public RoundsController(IRepository<Rounds> repository) : base(repository)
    { }
}