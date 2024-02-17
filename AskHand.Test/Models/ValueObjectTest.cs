using AskHand.Domain.Models;
using Moq;

namespace AskHand.Test.Models;

public class ValueObjectTest
{
    [Fact]
    public void Equals_ShouldReturnTrue_WhenObjectsAreEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1, "test");
        var valueObject2 = new TestValueObject(1, "test");

        // Act
        var result = valueObject1.Equals(valueObject2);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenObjectsAreNotEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1, "test");
        var valueObject2 = new TestValueObject(2, "test");

        // Act
        var result = valueObject1.Equals(valueObject2);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenObjectIsNull()
    {
        // Arrange
        var valueObject = new TestValueObject(1, "test");

        // Act
        var result = valueObject.Equals(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenObjectIsOfDifferentType()
    {
        // Arrange
        var valueObject = new TestValueObject(1, "test");

        // Act
        var result = valueObject.Equals(It.IsAny<object>());

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void GetHashCode_ShouldReturnSameHashCode_WhenObjectsAreEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1, "test");
        var valueObject2 = new TestValueObject(1, "test");

        // Act
        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        // Assert
        Assert.Equal(hashCode1, hashCode2);
    }

    [Fact]
    public void GetHashCode_ShouldReturnDifferentHashCode_WhenObjectsAreNotEqual()
    {
        // Arrange
        var valueObject1 = new TestValueObject(1, "test");
        var valueObject2 = new TestValueObject(2, "test");

        // Act
        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        // Assert
        Assert.NotEqual(hashCode1, hashCode2);
    }
    
    private class TestValueObject : ValueObject
    {
        private readonly int _id;
        private readonly string _name;

        public TestValueObject(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return _id;
            yield return _name;
        }
    }
}