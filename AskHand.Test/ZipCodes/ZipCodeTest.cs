using AskHand.Domain.ZipCodes;
using AskHand.Domain.ZipCodes.Exceptions;

namespace AskHand.Test.ZipCodes;

public class ZipCodeTest
{
    [Theory]
    [InlineData("12345")]
    [InlineData("90210")]
    [InlineData("12345-6789")]
    public void CreateZipCode_WithValidZipCode(string value)
    {
        // Act
        var zipCode = ZipCode.Create(value);

        // Assert
        Assert.NotNull(zipCode);
        Assert.Equal(value, zipCode.Value);
    }

    [Theory]
    [InlineData("1234")]
    [InlineData("123456")]
    [InlineData("1234-56789")]
    [InlineData("ABCDE")]
    public void ThrowsZipCodeFormatException_WithInvalidZipCode(string value)
    {
        // Act & Assert
        Assert.Throws<ZipCodeFormatException>(() => ZipCode.Create(value));
    }

    [Theory]
    [InlineData("12345")]
    [InlineData("90210")]
    [InlineData("12345-6789")]
    public void Should_GetEqualityComponents_WithValidLevel_ReturnCorrectComponent(string value)
    {
        // Arrange
        var level = ZipCode.Create(value);

        // Act
        var components = level.GetEqualityComponents();

        // Assert
        Assert.Contains(value, components);
    }
}