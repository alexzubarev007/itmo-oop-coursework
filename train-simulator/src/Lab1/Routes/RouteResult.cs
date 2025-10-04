using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Sections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public abstract record RouteResult
{
    private RouteResult() { }

    public sealed record Success(Time TotalTime) : RouteResult;

    public sealed record Failure(SectionResult FailedSection) : RouteResult;
}