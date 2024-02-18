namespace AskHand.Domain.Addresses.Exceptions;

public class AddressMissingArgumentException : Exception
{
    public AddressMissingArgumentException(string message)
        : base(message)
    {
        
    }
}