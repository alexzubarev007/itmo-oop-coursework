namespace Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;

public sealed record CannotSelectFileSystemError : IFileSystemError
{
    public string Message() => "Unknown filesystem";
}