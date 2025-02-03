using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class JimsDbContext(DbContextOptions<JimsDbContext> options) : DbContext(options)
{
    public DbSet<Entities.Order> Orders { get; set; } = null!;
    public DbSet<Entities.Job> Jobs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Order>(entity =>
        {
            entity.HasMany(o => o.Jobs)
                .WithOne(j => j.Order)
                .HasForeignKey(j => j.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Entities.Job>(entity => { entity.Property(j => j.Price).HasPrecision(18, 2); });
    }
}