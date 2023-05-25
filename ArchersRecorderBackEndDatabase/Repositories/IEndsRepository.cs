using ArchersRecorderBackEndDatabase.Data;
using ArchersRecorderBackEndDatabase.Models;

namespace ArchersRecorderBackEndDatabase.Repositories;

public interface IEndsRepository : IRepository<Ends>
{
    Task AddAsync(Ends ends);
}

public class EndsRepository : Repository<Ends>, IEndsRepository
{
    public EndsRepository(ArchersRecorderContext context) : base(context)
    { }

    public async Task AddAsync(Ends ends)
    {
        await _entities.AddAsync(ends);
        await _context.SaveChangesAsync();
    }
}
