using AskHand.Domain.Cities;

namespace AskHand.Test.Cities;

public class CityTest
{
    private const string ExpectedName = "Paris";

    [Fact]
    public void Create_ShouldSet_Name()
    {
        // Act
        var city = City.Create(ExpectedName);

        // Assert
        Assert.Equal(ExpectedName, city.Name);
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturn_Name()
    {
        // Arrange
        var city = City.Create(ExpectedName);

        // Act
        var components = city.GetEqualityComponents();

        // Assert
        Assert.Contains(ExpectedName, components);
    }
}