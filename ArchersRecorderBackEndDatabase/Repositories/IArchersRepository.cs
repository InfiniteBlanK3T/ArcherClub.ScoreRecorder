using ArchersRecorderBackEndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using ArchersRecorderBackEndDatabase.Data;

namespace ArchersRecorderBackEndDatabase.Repositories;

public interface IArchersRepository
{
    Task<IEnumerable<Archers>> GetAllAsync();
    Task<Archers> GetByIdAsync(int ArcherId);
    Task<IEnumerable<Archers>> GetByQueryAsync(string query);
}

public class ArchersRepository : IArchersRepository
{
    private readonly DbSet<Archers> _entities;

    public ArchersRepository(ArchersRecorderContext context)
    {
        _entities = context.Set<Archers>();
    }

    public async Task<IEnumerable<Archers>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<Archers> GetByIdAsync(int ArcherId)
    {
        return await _entities.FindAsync(ArcherId);
    }
    public async Task<IEnumerable<Archers>> GetByQueryAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return new List<Archers>();
        }

        query = query.ToLower();

        return await _entities
            .Where(a => a.GivenName.ToLower().Contains(query)
                     || a.FamilyName.ToLower().Contains(query))
            .ToListAsync();
    }
}
