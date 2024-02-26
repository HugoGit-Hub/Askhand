using AskHand.Domain.Passwords.Exceptions;
using AskHand.Domain.Passwords;

namespace AskHand.Test.Domain.Passwords;

public class PasswordTest
{
    [Fact]
    public void Create_ShouldReturnPassword_WhenPasswordIsValid()
    {
        // Arrange
        const string validPassword = "ValidPassword123!";

        // Act
        var password = Password.Create(validPassword);

        // Assert
        Assert.NotNull(password);
        Assert.Equal(validPassword, password.Value);
    }

    [Fact]
    public void Create_ShouldThrowPasswordFormatException_WhenPasswordIsInvalid()
    {
        // Arrange
        const string invalidPassword = "invalid";

        // Act & Assert
        Assert.Throws<PasswordFormatException>(() => Password.Create(invalidPassword));
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnSameComponents_WhenPasswordsAreEqual()
    {
        // Arrange
        var password1 = Password.Create("testPassword123!");
        var password2 = Password.Create("testPassword123!");

        // Act
        var components1 = password1.GetEqualityComponents().ToList();
        var components2 = password2.GetEqualityComponents().ToList();

        // Assert
        Assert.Equal(components1, components2);
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnDifferentComponents_WhenPasswordsAreNotEqual()
    {
        // Arrange
        var password1 = Password.Create("testPassword123!");
        var password2 = Password.Create("differentPassword123!");

        // Act
        var components1 = password1.GetEqualityComponents().ToList();
        var components2 = password2.GetEqualityComponents().ToList();

        // Assert
        Assert.NotEqual(components1, components2);
    }
}