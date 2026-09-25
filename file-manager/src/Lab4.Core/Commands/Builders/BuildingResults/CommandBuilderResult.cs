namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;

public record CommandBuilderResult
{
    private CommandBuilderResult() { }

    public sealed record Success(ICommand Command) : CommandBuilderResult;

    public sealed record Failure : CommandBuilderResult;
}