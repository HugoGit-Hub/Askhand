using AskHand.Domain.Cities;
using AskHand.Domain.Countries;
using AskHand.Domain.Emails;
using AskHand.Domain.Passwords;
using AskHand.Domain.Skills;
using AskHand.Domain.Users;

namespace AskHand.Test.Domain.Users;

public class UserTest
{
    [Fact]
    public void Create_ShouldReturnUser_WhenValidArgumentsProvided()
    {
        // Arrange
        var email = Email.Create("test@example.com");
        var password = Password.Create("password123");
        const string firstName = "John";
        const string lastName = "Doe";
        const int age = 25;
        const string pictureProfilPath = "/path/to/profile/pic";
        var metadata = new UserMetaData(firstName, lastName, age, pictureProfilPath);
        var skill = Skill.Create(5);
        var city = City.Create("Paris");
        var country = Country.Create("France");

        // Act
        var user = User.Create(email, password, metadata, skill, city, country);

        // Assert
        Assert.NotNull(user);
        Assert.Equal(email, user.Email);
        Assert.Equal(password, user.Password);
        Assert.Equal(metadata, user.MetaData);
        Assert.Equal(skill, user.Skill);
        Assert.Equal(city, user.City);
        Assert.Equal(country, user.Country);
    }
}