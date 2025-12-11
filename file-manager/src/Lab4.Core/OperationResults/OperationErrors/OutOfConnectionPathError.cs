namespace Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;

public sealed record OutOfConnectionPathError : IFileSystemError
{
    public string Message() => "The path is out of connection path";
}