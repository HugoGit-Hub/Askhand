using AskHand.Domain.Levels;
using AskHand.Domain.Levels.Exceptions;

namespace AskHand.Test.Domain.Levels;

public class LevelTest
{
    [Theory]
    [InlineData("4+")]
    [InlineData("8A")]
    [InlineData("6b+")]
    public void Should_CreateLevel_WithValidRate(string rate)
    {
        // Act
        var level = Level.Create(rate);

        // Assert
        Assert.NotNull(level);
        Assert.Equal(rate, level.Rate);
    }

    [Theory]
    [InlineData("")]
    [InlineData("3")]
    [InlineData("10A")]
    public void Should_ThrowsRateFormatException_WithInvalidRate(string rate)
    {
        // Act & Assert
        Assert.Throws<RateFormatException>(() => Level.Create(rate));
    }

    [Theory]
    [InlineData("4+")]
    [InlineData("8A")]
    [InlineData("6b+")]
    public void Should_GetEqualityComponents_WithValidLevel_ReturnCorrectComponent(string rate)
    {
        // Arrange
        var level = Level.Create(rate);

        // Act
        var components = level.GetEqualityComponents();

        // Assert
        Assert.Contains(rate, components);
    }
}