using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record DistanceResult
{
    private DistanceResult() { }

    public sealed record Success(Time TotalTime) : DistanceResult;

    public sealed record PrematureStop : DistanceResult;
}