namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;

public sealed record NonExistPathError : ICommandError
{
    public string Message() => "The path doesn't exist";
}