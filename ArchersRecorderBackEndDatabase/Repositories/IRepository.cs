using Microsoft.EntityFrameworkCore;
using ArchersRecorderBackEndDatabase.Data;

namespace ArchersRecorderBackEndDatabase.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
}

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbSet<T> _entities;
    protected readonly ArchersRecorderContext _context;

    public Repository(ArchersRecorderContext context)
    {
        _entities = context.Set<T>();
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _entities.FindAsync(id);
    }
}
