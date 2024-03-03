using AskHand.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AskHand.Infrastructure.Context.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUserTable(builder);
    }

    private static void ConfigureUserTable(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value, 
                value => UserId.Create(value));

        builder.OwnsOne(
            e => e.Email,
            email =>
            {
                email.Property(e => e.Value);
            });
        
        builder.OwnsOne(
            e => e.Password,
            password =>
            {
                password.Property(e => e.Value);
            });

        builder.OwnsOne(
            e => e.MetaData, 
            metaData => 
            {
                metaData.Property(e => e.FirstName);
                metaData.Property(e => e.LastName);
                metaData.Property(e => e.Age);
                metaData.Property(e => e.PictureProfilPath);
            });

        builder.OwnsOne(
           e => e.Skill,
           skill =>
           {
                skill.Property(e => e.Level);
           });

        builder.OwnsOne(
           e => e.City,
           city =>
           { 
               city.Property(e => e.Name);
           });

        builder.OwnsOne(
            e => e.Country,
            country => 
            {
               country.Property(e => e.Name);
           });
    }
}