namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;

public sealed record WritingError : ICommandError
{
    public string Message() => "Unable to write";
}