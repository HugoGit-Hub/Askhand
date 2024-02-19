namespace AskHand.Domain.Friendships;

public sealed class FriendshipId : ValueObject
{
    public Guid Value { get; }

    private FriendshipId(Guid value)
    {
        Value = value;
    }

    public static FriendshipId CreateUnique()
    {
        return new FriendshipId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}