namespace AskHand.Domain.Cities.Exceptions;

public class CityMissingArgumentException : Exception
{
    public CityMissingArgumentException(string message) 
        : base(message)
    {
    }
}