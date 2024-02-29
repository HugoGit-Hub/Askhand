namespace AskHand.Domain.Countries.Exceptions;

public class CountryMissingArgumentException : Exception
{
    public CountryMissingArgumentException(string message)
        : base(message)
    {
    }
}