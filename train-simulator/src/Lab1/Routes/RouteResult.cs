using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public abstract record RouteResult
{
    private RouteResult() { }

    public sealed record Success(Time TotalTime) : RouteResult;

    public sealed record Failure(IError FailedSection) : RouteResult;
}