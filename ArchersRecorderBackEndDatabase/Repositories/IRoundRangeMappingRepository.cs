using ArchersRecorderBackEndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using ArchersRecorderBackEndDatabase.Data;

namespace ArchersRecorderBackEndDatabase.Repositories;

public interface IRoundRangeMappingRepository
{
    Task<IEnumerable<RoundRangeMapping>> GetAllAsync();
    Task<RoundRangeMapping> GetByIdAsync(int roundId, int rangeId);
}

public class RoundRangeMappingRepository : IRoundRangeMappingRepository
{
    private readonly DbSet<RoundRangeMapping> _entities;

    public RoundRangeMappingRepository(ArchersRecorderContext context)
    {
        _entities = context.Set<RoundRangeMapping>();
    }

    public async Task<IEnumerable<RoundRangeMapping>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<RoundRangeMapping> GetByIdAsync(int roundId, int rangeId)
    {
        return await _entities.FindAsync(roundId, rangeId);
    }
}
