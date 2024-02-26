using AskHand.Domain.Skills.Exceptions;
using AskHand.Domain.Skills;

namespace AskHand.Test.Domain.Skills;

public class SkillTest
{
    [Fact]
    public void Create_ShouldReturnSkill_WhenLevelIsValid()
    {
        // Arrange
        var validLevel = 50;

        // Act
        var skill = Skill.Create(validLevel);

        // Assert
        Assert.NotNull(skill);
        Assert.Equal(validLevel, skill.Level);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(101)]
    public void Create_ShouldThrowWrongSkillLevelException_WhenLevelIsInvalid(int invalidLevel)
    {
        // Act & Assert
        Assert.Throws<WrongSkillLevelException>(() => Skill.Create(invalidLevel));
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnSameComponents_WhenSkillsAreEqual()
    {
        // Arrange
        var skill1 = Skill.Create(50);
        var skill2 = Skill.Create(50);

        // Act
        var components1 = skill1.GetEqualityComponents().ToList();
        var components2 = skill2.GetEqualityComponents().ToList();

        // Assert
        Assert.Equal(components1, components2);
    }

    [Fact]
    public void GetEqualityComponents_ShouldReturnDifferentComponents_WhenSkillsAreNotEqual()
    {
        // Arrange
        var skill1 = Skill.Create(50);
        var skill2 = Skill.Create(60);

        // Act
        var components1 = skill1.GetEqualityComponents().ToList();
        var components2 = skill2.GetEqualityComponents().ToList();

        // Assert
        Assert.NotEqual(components1, components2);
    }
}