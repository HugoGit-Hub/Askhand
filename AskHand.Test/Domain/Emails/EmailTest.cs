using AskHand.Domain.Emails;
using AskHand.Domain.Emails.Exceptions;

namespace AskHand.Test.Domain.Emails;

public class EmailTest
{
    [Fact]
    public void Create_ShouldReturnEmail_WhenEmailIsValid()
    {
        // Arrange
        const string validEmail = "test@test.com";

        // Act
        var email = Email.Create(validEmail);

        // Assert
        Assert.NotNull(email);
        Assert.Equal(validEmail, email.Value);
    }

    [Fact]
    public void Create_ShouldThrowEmailFormatException_WhenEmailIsInvalid()
    {
        // Arrange
        const string invalidEmail = "invalidEmail";

        // Act & Assert
        Assert.Throws<EmailFormatException>(() => Email.Create(invalidEmail));
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnSameComponents_WhenEmailsAreEqual()
    {
        // Arrange
        var email1 = Email.Create("test@test.com");
        var email2 = Email.Create("test@test.com");

        // Act
        var components1 = email1.GetEqualityComponents().ToList();
        var components2 = email2.GetEqualityComponents().ToList();

        // Assert
        Assert.Equal(components1, components2);
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnDifferentComponents_WhenEmailsAreNotEqual()
    {
        // Arrange
        var email1 = Email.Create("test1@test.com");
        var email2 = Email.Create("test2@test.com");

        // Act
        var components1 = email1.GetEqualityComponents().ToList();
        var components2 = email2.GetEqualityComponents().ToList();

        // Assert
        Assert.NotEqual(components1, components2);
    }
}