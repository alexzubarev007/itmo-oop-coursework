using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Sections.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public abstract record SectionResult
{
    private SectionResult() { }

    public sealed record Success(Time Time) : SectionResult { }

    public sealed record Failure(ISectionErrors Error) : SectionResult { }
}