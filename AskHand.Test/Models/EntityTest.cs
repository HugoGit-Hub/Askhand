using AskHand.Domain.Models;

namespace AskHand.Test.Models;

public class EntityTest
{
    [Fact]
    public void Equals_ShouldReturnTrue_WhenEntitiesHaveSameId()
    {
        // Arrange
        var entity1 = new TestEntity(1);
        var entity2 = new TestEntity(1);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenEntitiesHaveDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntity(1);
        var entity2 = new TestEntity(2);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetHashCode_ShouldReturnSameHashCode_WhenEntitiesHaveSameId()
    {
        // Arrange
        var entity1 = new TestEntity(1);
        var entity2 = new TestEntity(1);

        // Act
        var hashCode1 = entity1.GetHashCode();
        var hashCode2 = entity2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    [Fact]
    public void GetHashCode_ShouldReturnDifferentHashCode_WhenEntitiesHaveDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntity(1);
        var entity2 = new TestEntity(2);

        // Act
        var hashCode1 = entity1.GetHashCode();
        var hashCode2 = entity2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }

    private class TestEntity : Entity<int>
    {
        public TestEntity(int id) : base(id)
        {
        }
    }
}