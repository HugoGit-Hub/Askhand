using AskHand.Domain.Addresses;
using AskHand.Domain.Cities;
using AskHand.Domain.Countries;
using AskHand.Domain.Levels;
using AskHand.Domain.Walls;
using AskHand.Domain.ZipCodes;
using Moq;

namespace AskHand.Test.Walls;

public class WallTest
{
    [Fact]
    public void Create_ShouldCreateWallWithGivenValues()
    {
        // Arrange
        var level = Level.Create("6A");
        var zipCode = ZipCode.Create("12345");
        var city = City.Create("City");
        var country = Country.Create("Country");
        var address = Address.Create("123", "Main St", zipCode, city, country);

        // Act
        var wall = Wall.Create(level, true, true, true, address);

        // Assert
        Assert.Equal(level.Rate, wall.Level.Rate);
        Assert.True(wall.IsIndoor);
        Assert.True(wall.IsBlock);
        Assert.True(wall.IsPresent);
        Assert.Equal(address, wall.Address);
    }

    [Fact]
    public void Constructor_ShouldThrowException_WhenLevelIsNull()
    {
        // Arrange
        var zipCode = ZipCode.Create("12345");
        var city = City.Create("City");
        var country = Country.Create("Country");
        var address = Address.Create("123", "Main St", zipCode, city, country);

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => Wall.Create(It.IsAny<Level>(), true, true, true, address));
    }

    [Fact]
    public void Constructor_ShouldThrowException_WhenAddressIsNull()
    {
        // Arrange
        var level = Level.Create("6A");

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => Wall.Create(level, true, true, true, It.IsAny<Address>()));
    }
}