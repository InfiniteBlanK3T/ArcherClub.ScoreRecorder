using Microsoft.EntityFrameworkCore;
using ArchersRecorderBackEndDatabase.Models;

namespace ArchersRecorderBackEndDatabase.Data;

public class ArchersRecorderContext : DbContext
{
    public ArchersRecorderContext(DbContextOptions<ArchersRecorderContext> options) : base(options)
    { }

    public DbSet<Archers> Archers { get; set; }
    public DbSet<Ends> Ends { get; set; }
    public DbSet<Equipments> Equipments { get; set; }
    public DbSet<Ranges> Ranges { get; set; }
    public DbSet<RoundRangeMapping> RoundRangeMappings { get; set; }
    public DbSet<Rounds> Rounds { get; set; }
    public DbSet<RoundScores> RoundScores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoundRangeMapping>()
            .HasKey(at => new { at.RangeId, at.RoundId });

    }
}
