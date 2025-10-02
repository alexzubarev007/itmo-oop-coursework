using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public abstract record RouteResult
{
    private RouteResult() { }

    public sealed record Success(Time TotalTime) : RouteResult;

    public sealed record Failure(SectionResult FailedSection) : RouteResult;
}