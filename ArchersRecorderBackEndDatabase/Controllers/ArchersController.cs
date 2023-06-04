using ArchersRecorderBackEndDatabase.Models;
using ArchersRecorderBackEndDatabase.Repositories;

namespace ArchersRecorderBackEndDatabase.Controllers;

public class ArchersController : GenericController<Archers>
{
    public ArchersController(IRepository<Archers> repository) : base(repository)
    {  }
}
