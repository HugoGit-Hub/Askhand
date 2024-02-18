using AskHand.Domain.Countries;

namespace AskHand.Test.Countries;

public class CountryTest
{
    private const string ExpectedName = "France";

    [Fact]
    public void Create_ShouldSet_Name()
    {
        // Act
        var country = Country.Create(ExpectedName);

        // Assert
        Assert.Equal(ExpectedName, country.Name);
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturn_Name()
    {
        // Arrange
        var country = Country.Create(ExpectedName);

        // Act
        var components = country.GetEqualityComponents();

        // Assert
        Assert.Contains(ExpectedName, components);
    }
}