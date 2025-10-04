using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public abstract record SectionResult
{
    private SectionResult() { }

    public sealed record Success(Time Time) : SectionResult { }

    public sealed record Failure(IError Error) : SectionResult { }
}