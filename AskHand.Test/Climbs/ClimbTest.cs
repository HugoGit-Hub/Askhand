using AskHand.Domain.Climbs.Exceptions;
using AskHand.Domain.Climbs;

namespace AskHand.Test.Climbs;

public class ClimbTest
{
    [Fact]
    public void Create_ShouldReturnClimb_WhenValidArgumentsProvided()
    {
        // Arrange
        var id = ClimbId.CreateUnique();
        const double estimationTime = 10.5;
        const double validationRate = 85.5;

        // Act
        var climb = new Climb(id, estimationTime, validationRate);

        // Assert
        Assert.NotNull(climb);
        Assert.Equal(id, climb.Id);
        Assert.Equal(estimationTime, climb.EstimationTime);
        Assert.Equal(validationRate, climb.ValidationRate);
    }

    [Theory]
    [InlineData(-1, 85.5)]
    [InlineData(10.5, -1)]
    [InlineData(10.5, 101)]
    public void Create_ShouldThrowClimbWrongFormatException_WhenInvalidArgumentsProvided(
        double estimationTime,
        double validationRate)
    {
        // Arrange
        var id = ClimbId.CreateUnique();

        // Act & Assert
        Assert.Throws<ClimbWrongFormatException>(() => new Climb(id, estimationTime, validationRate));
    }
}