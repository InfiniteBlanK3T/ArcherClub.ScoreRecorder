using ArchersRecorderBackEndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using ArchersRecorderBackEndDatabase.Data;

namespace ArchersRecorderBackEndDatabase.Repositories;

public interface IRoundRangeMappingRepository
{
    Task<IEnumerable<RoundRangeMapping>> GetAllAsync();
    Task<IEnumerable<RoundRangeMapping>> GetByIdAsync(int roundId);
    Task<RoundRangeMapping> GetBySpecificIdAsync(int roundId, int rangeId);
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

    public async Task<IEnumerable<RoundRangeMapping>> GetByIdAsync(int roundId)
    {
        return await _entities.Where(r => r.RoundId == roundId).ToListAsync();
    }


    public async Task<RoundRangeMapping> GetBySpecificIdAsync(int roundId, int rangeId)
    {
        return await _entities.FindAsync(roundId, rangeId);
    }
}
