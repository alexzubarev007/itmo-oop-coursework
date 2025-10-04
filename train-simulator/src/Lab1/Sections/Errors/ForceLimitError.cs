using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections.Errors;

public sealed record ForceLimitError(Force Limit) : ISectionErrors
{
    public string Message()
    {
        return $"Force limit {Limit.Value} failed.";
    }
}