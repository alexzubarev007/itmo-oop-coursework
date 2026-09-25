using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Errors;

public sealed record ForceLimitError(Force Limit) : IError
{
    public string Message()
    {
        return $"Force limit {Limit.Value} failed.";
    }
}