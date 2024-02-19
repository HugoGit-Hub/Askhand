using AskHand.Domain.Climbs.Exceptions;
using AskHand.Domain.Users;
using AskHand.Domain.Walls;

namespace AskHand.Domain.Climbs;

public sealed class Climb : Entity<ClimbId>
{
    public double EstimationTime { get; }

    public double ValidationRate { get; }

    public User User { get; } = null!;

    public Wall Wall { get; } = null!;

    public Climb(ClimbId id,
        double estimationTime,
        double validationRate) 
        : base(id)
    {
        if (estimationTime < 0 ||
            validationRate < 0 ||
            validationRate > 100)
        {
            throw new ClimbWrongFormatException();
        }

        EstimationTime = Math.Round(estimationTime, 2);
        ValidationRate = Math.Round(validationRate, 2);
    }
}