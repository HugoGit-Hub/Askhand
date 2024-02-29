namespace AskHand.Domain.Skills.Exceptions;

public class WrongSkillLevelException : Exception
{
    public WrongSkillLevelException(string message)
        : base(message)
    {
    }
}