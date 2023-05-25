using Microsoft.EntityFrameworkCore;
using BackEnd.Models;

namespace BackEnd.Data;
public class BackEndContext : DbContext
{
    public BackEndContext(DbContextOptions<BackEndContext> options) : base(options)
    { }
    public DbSet<Archers> Archers { get; set; }
    public DbSet<Clubs> Clubs { get; set; }
    public DbSet<Distances> Distances { get; set; }
    public DbSet<Ends> Ends { get; set; }
    public DbSet<Equipments> Equipments { get; set; }
    public DbSet<EquivalentRounds> EquivalentRounds { get; set; }
    public DbSet<Events> Events { get; set; }
    public DbSet<FaceSizes> FaceSizes { get; set; }
    public DbSet<MultiEvent> MultiEvent { get; set; }
    public DbSet<Ranges> Ranges { get; set; }
    public DbSet<RoundGroups> RoundGroups { get; set; }
    public DbSet<RoundRangeMapping> RoundRangeMapping { get; set; }
    public DbSet<Rounds> Rounds { get; set; }
    public DbSet<RoundScore> RoundScore { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RoundRangeMapping>()
            .HasKey(RRM => new { RRM.RoundId, RRM.RangeID });

        modelBuilder.Entity<Distances>()
            .Property(Dis => Dis.Distance)
            .ValueGeneratedNever();

        modelBuilder.Entity<FaceSizes>()
            .Property(Fs => Fs.FaceSize)
            .ValueGeneratedNever();
    }



}
