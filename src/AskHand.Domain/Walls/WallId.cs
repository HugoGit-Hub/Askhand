namespace AskHand.Domain.Walls;

public sealed class WallId : ValueObject
{
    public Guid Value { get; }

    private WallId (Guid value)
    {
        Value = value;
    }

    public static WallId CreateUnique()
    {
        return new WallId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}