using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Errors;

public sealed record SpeedLimitError(Speed Limit) : IError
{
    public string Message()
    {
        return $"Speed limit {Limit.Value} failed.";
    }
}