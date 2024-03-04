using AskHand.Domain.Friendships;
using AskHand.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AskHand.Infrastructure.Context.Configurations;

public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
{
    public void Configure(EntityTypeBuilder<Friendship> builder)
    {
        ConfigureFriendshipTable(builder);
    }

    private static void ConfigureFriendshipTable(EntityTypeBuilder<Friendship> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => FriendshipId.Create(value));

        builder.Property(e => e.UserIdOne)
            .ValueGeneratedNever()
            .HasConversion(
                userIdOne => userIdOne.Value,
                value => UserId.Create(value));
        
        builder.Property(e => e.UserIdTwo)
            .ValueGeneratedNever()
            .HasConversion(
                userIdOne => userIdOne.Value,
                value => UserId.Create(value));

        builder.Property(e => e.StartFriendshipDate);
        builder.Property(e => e.EndFriendshipDate);
    }
}