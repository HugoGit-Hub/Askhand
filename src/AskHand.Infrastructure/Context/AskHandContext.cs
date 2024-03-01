using AskHand.Domain.Climbs;
using AskHand.Domain.Walls;
using AskHand.Infrastructure.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AskHand.Infrastructure.Context;

public class AskHandContext(DbContextOptions<AskHandContext> options) : DbContext(options)
{
    public DbSet<Climb> Climbs { get; set; } = null!;

    public DbSet<Wall> Walls { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new ClimbConfiguration().Configure(modelBuilder.Entity<Climb>());
        new WallConfiguration().Configure(modelBuilder.Entity<Wall>());
    }
};