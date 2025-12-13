namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;

public sealed record DisconnectingError : ICommandError
{
    public string Message() => "The filesystem is disconnected.";
}