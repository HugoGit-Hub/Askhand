using AskHand.Domain.Walls;

namespace AskHand.Test.Domain.Walls;

public class WallIdTest
{
    [Fact]
    public void CreateUnique_ShouldReturnWallId()
    {
        // Act
        var wallId = WallId.CreateUnique();

        // Assert
        Assert.NotNull(wallId);
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnNotEqual_WhenDifferentWallIdProvided()
    {
        // Arrange
        var wallId1 = WallId.CreateUnique();
        var wallId2 = WallId.CreateUnique();

        // Act
        var result = wallId1.GetEqualityComponents().SequenceEqual(wallId2.GetEqualityComponents());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Create_ShouldReturnWallId_WithSameGuidValue()
    {
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var wallId = WallId.Create(guid);

        // Assert
        Assert.NotNull(wallId);
        Assert.IsType<WallId>(wallId);
        Assert.Equal(guid, wallId.Value);
    }
}