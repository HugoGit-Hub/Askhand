using AskHand.Domain.Friendships;
using AskHand.Domain.Users;

namespace AskHand.Test.Friendships;

public class FriendshipTest
{
    [Fact]
    public void Create_ShouldReturnFriendship_WhenValidArgumentsProvided()
    {
        // Arrange
        var userIdOne = UserId.CreateUnique();
        var userIdTwo = UserId.CreateUnique();
        var startFriendshipDate = DateTime.Now.AddDays(-10);
        var endFriendshipDate = DateTime.Now;

        // Act
        var friendship = Friendship.Create(userIdOne, userIdTwo, startFriendshipDate, endFriendshipDate);

        // Assert
        Assert.NotNull(friendship);
        Assert.Equal(userIdOne, friendship.UserIdOne);
        Assert.Equal(userIdTwo, friendship.UserIdTwo);
        Assert.Equal(startFriendshipDate, friendship.StartFriendshipDate);
        Assert.Equal(endFriendshipDate, friendship.EndFriendshipDate);
    }
}