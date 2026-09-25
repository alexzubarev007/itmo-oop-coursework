namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;

public sealed record OutOfConnectionPathError : ICommandError
{
    public string Message() => "The path is out of connection path";
}