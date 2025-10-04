using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections.Errors;

public sealed record SpeedLimitError(Speed Limit) : ISectionErrors
{
    public string Message()
    {
        return $"Speed limit {Limit.Value} failed.";
    }
}