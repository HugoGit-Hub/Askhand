namespace AskHand.Domain.Climbs;

public sealed class ClimbId : ValueObject
{
    public Guid Value { get; }

    private ClimbId(Guid value)
    {
        Value = value;
    }

    public static ClimbId CreateUnique()
    {
        return new ClimbId(Guid.NewGuid());
    }
    
    public static ClimbId Create(Guid value)
    {
        return new ClimbId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}