using AskHand.Domain.Users;
using AskHand.Domain.Users.Exceptions;

namespace AskHand.Test.Domain.Users;

public class UserMetaDataTest
{
    [Fact]
    public void Create_ShouldReturnUserMetaData_WhenValidArgumentsProvided()
    {
        // Arrange
        const string firstName = "John";
        const string lastName = "Doe";
        const int age = 25;
        const string pictureProfilPath = "/path/to/profile/pic";

        // Act
        var userMetaData = new UserMetaData(firstName, lastName, age, pictureProfilPath);

        // Assert
        Assert.Equal(firstName, userMetaData.FirstName);
        Assert.Equal(lastName, userMetaData.LastName);
        Assert.Equal(age, userMetaData.Age);
        Assert.Equal(pictureProfilPath, userMetaData.PictureProfilPath);
    }

    [Theory]
    [InlineData(null, "Doe", 25, "/path/to/profile/pic")]
    [InlineData("John", null, 25, "/path/to/profile/pic")]
    [InlineData("John", "Doe", 25, null)]
    public void Create_ShouldThrowUserMetaDataFormatException_WhenNullArgumentsProvided(
        string firstName,
        string lastName,
        int age,
        string pictureProfilPath)
    {
        // Act & Assert
        Assert.Throws<UserMetaDataFormatException>(() => new UserMetaData(firstName, lastName, age, pictureProfilPath));
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnAllProperties()
    {
        // Arrange
        const string firstName = "John";
        const string lastName = "Doe";
        const int age = 25;
        const string pictureProfilPath = "/path/to/profile/pic";
        var userMetaData = new UserMetaData(firstName, lastName, age, pictureProfilPath);

        // Act
        var components = userMetaData.GetEqualityComponents().ToList();

        // Assert
        Assert.Equal(4, components.Count);
        Assert.Equal(firstName, components[0]);
        Assert.Equal(lastName, components[1]);
        Assert.Equal(age, components[2]);
        Assert.Equal(pictureProfilPath, components[3]);
    }

}