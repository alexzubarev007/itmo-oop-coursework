namespace Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;

public sealed record DisconnectingError : IFileSystemError
{
    public string Message() => "The filesystem is disconnected.";
}