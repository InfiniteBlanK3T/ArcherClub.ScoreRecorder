using ArchersRecorderBackEndDatabase.Data;
using ArchersRecorderBackEndDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchersRecorderBackEndDatabase.Repositories;

public interface IRoundScoresRepository : IRepository<RoundScores>
{
    Task AddAsync(RoundScores roundScores);
}

public class RoundScoresRepository : Repository<RoundScores>, IRoundScoresRepository
{

    public RoundScoresRepository(ArchersRecorderContext context) : base(context)
    {  }

    public async Task AddAsync(RoundScores roundScores)
    {
        await _entities.AddAsync(roundScores);
        await _context.SaveChangesAsync();
    }
}

public class RoundScoresService
{
    private readonly IRoundScoresRepository _repository;

    public RoundScoresService(IRoundScoresRepository repository)
    {
        _repository = repository;
    }

    public async Task AddRoundScoresAsync(RoundScores roundScores)
    {
        await _repository.AddAsync(roundScores);
    }
}


