using AskHand.Domain.Addresses;
using AskHand.Domain.Addresses.Exceptions;
using AskHand.Domain.Cities;
using AskHand.Domain.Cities.Exceptions;
using AskHand.Domain.Countries;
using AskHand.Domain.Countries.Exceptions;
using AskHand.Domain.ZipCodes;
using AskHand.Domain.ZipCodes.Exceptions;

namespace AskHand.Test.Domain.Addresses;

public class AddressTest
{
    [Fact]
    public void Create_ShouldReturnAddress_WhenValidArgumentsProvided()
    {
        // Arrange
        const string number = "123";
        const string street = "Main St";
        var zipCode = ZipCode.Create("12345");
        var city = City.Create("Paris");
        var country = Country.Create("France");

        // Act
        var address = Address.Create(number, street, zipCode, city, country);

        // Assert
        Assert.NotNull(address);
        Assert.Equal(number, address.Number);
        Assert.Equal(street, address.Street);
        Assert.Equal(zipCode, address.ZipCode);
        Assert.Equal(city, address.City);
        Assert.Equal(country, address.Country);
    }

    [Theory]
    [InlineData(null, "Main St", "12345", "Paris", "France")]
    [InlineData("123", null, "12345", "Paris", "France")]
    public void Create_ShouldThrowAddressMissingArgumentException_WhenNullArgumentsProvided(
        string number,
        string street,
        string zipCode,
        string city,
        string country)
    {
        // Arrange & Act & Assert
        Assert.Throws<AddressMissingArgumentException>(() => Address.Create(
            number,
            street,
            ZipCode.Create(zipCode),
            City.Create(city),
            Country.Create(country)));
    }

    [Theory]
    [InlineData(null, "Paris", "France", nameof(ZipCodeFormatException))]
    [InlineData("12345", null, "France", nameof(CityMissingArgumentException))]
    [InlineData("12345", "Paris", null, nameof(CountryMissingArgumentException))]
    public void Create_ShouldThrowAddressMissingArgumentException_WhenInvalidValueObjectArgumentsProvided(
        string zipCodeValue,
        string cityName,
        string countryName,
        string exception)
    {
        // Arrange
        const string number = "123";
        const string street = "Main St";

        // Act & Assert
        switch (exception)
        {
            case nameof(ZipCodeFormatException):
                Assert.Throws<ZipCodeFormatException>(() => Address.Create(number,
                    street,
                    ZipCode.Create(zipCodeValue),
                    City.Create(cityName),
                    Country.Create(countryName)));
                break;
            case nameof(CityMissingArgumentException):
                Assert.Throws<CityMissingArgumentException>(() => Address.Create(number,
                    street,
                    ZipCode.Create(zipCodeValue),
                    City.Create(cityName),
                    Country.Create(countryName)));
                break;
            case nameof(CountryMissingArgumentException):
                Assert.Throws<CountryMissingArgumentException>(() => Address.Create(number,
                    street,
                    ZipCode.Create(zipCodeValue),
                    City.Create(cityName),
                    Country.Create(countryName)));
                break;
        }
    }

    [Fact]
    public void Create_ShouldThrowAddressNumberFormatException_WhenInvalidNumberProvided()
    {
        // Arrange
        const string number = "abc";
        const string street = "Main St";
        var zipCode = ZipCode.Create("12345");
        var city = City.Create("Paris");
        var country = Country.Create("France");

        // Act & Assert
        Assert.Throws<AddressNumberFormatException>(() => Address.Create(number, street, zipCode, city, country));
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnEqual_WhenSameAddressProvided()
    {
        // Arrange
        const string number = "123";
        const string street = "Main St";
        var zipCode = ZipCode.Create("12345");
        var city = City.Create("Paris");
        var country = Country.Create("France");
        var address1 = Address.Create(number, street, zipCode, city, country);
        var address2 = Address.Create(number, street, zipCode, city, country);

        // Act
        var result = address1.GetEqualityComponents().SequenceEqual(address2.GetEqualityComponents());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnNotEqual_WhenDifferentAddressProvided()
    {
        // Arrange
        const string street = "Main St";
        var zipCode = ZipCode.Create("12345");
        var city = City.Create("Paris");
        var country = Country.Create("France");
        var address1 = Address.Create("123", street, zipCode, city, country);
        var address2 = Address.Create("124", street, zipCode, city, country);

        // Act
        var result = address1.GetEqualityComponents().SequenceEqual(address2.GetEqualityComponents());

        // Assert
        Assert.False(result);
    }
}