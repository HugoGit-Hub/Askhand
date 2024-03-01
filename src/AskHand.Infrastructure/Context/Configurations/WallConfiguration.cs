using AskHand.Domain.Walls;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AskHand.Infrastructure.Context.Configurations;

public class WallConfiguration : IEntityTypeConfiguration<Wall>
{
    public void Configure(EntityTypeBuilder<Wall> builder)
    {
        ConfigureWallTable(builder);
    }

    private static void ConfigureWallTable(EntityTypeBuilder<Wall> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value, 
                value => WallId.Create(value));

        builder.OwnsOne(
            e => e.Level,
            level =>
            {
                level.Property(e => e.Rate);
            });

        builder.OwnsOne(e => e.Address, address =>
        {
            address.Property(e => e.Number);
            address.Property(e => e.Street);
            address.OwnsOne(e => e.ZipCode, zipCode =>
            {
                zipCode.Property(e => e.Value);
            });

            address.OwnsOne(e => e.City, city =>
            {
                city.Property(e => e.Name);
            });

            address.OwnsOne(e => e.Country, country =>
            {
                country.Property(e => e.Name);
            });
        });
    }
}