using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record TrainResult
{
    private TrainResult() { }

    public sealed record Success(Time TotalTime) : TrainResult;

    public sealed record PrematureStop : TrainResult;
}