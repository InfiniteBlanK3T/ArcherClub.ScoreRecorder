using ArchersRecorderBackEndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using ArchersRecorderBackEndDatabase.Data;

namespace ArchersRecorderBackEndDatabase.Repositories;

public interface IEquipmentRepository
{
    Task<IEnumerable<Equipments>> GetAllAsync();
    Task<Equipments> GetByNameAsync(string name);
}

public class EquipmentRepository : IEquipmentRepository
{
    private readonly DbSet<Equipments> _entities;

    public EquipmentRepository(ArchersRecorderContext context)
    {
        _entities = context.Set<Equipments>();
    }

    public async Task<IEnumerable<Equipments>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<Equipments> GetByNameAsync(string name)
    {
        return await _entities.FindAsync(name);
    }
}

