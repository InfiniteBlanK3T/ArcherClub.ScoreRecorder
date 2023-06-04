using ArchersRecorderBackEndDatabase.Models;
using ArchersRecorderBackEndDatabase.Repositories;

namespace ArchersRecorderBackEndDatabase.Controllers;

public class RangesController : GenericController<Ranges>
{
    public RangesController(IRepository<Ranges> repository) : base(repository)
    { }
}
