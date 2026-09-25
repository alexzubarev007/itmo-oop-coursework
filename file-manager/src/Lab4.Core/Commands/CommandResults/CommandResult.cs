using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;

public record CommandResult
{
    private CommandResult() { }

    public sealed record Success : CommandResult;

    public sealed record Failure(ICommandError Error) : CommandResult;
}