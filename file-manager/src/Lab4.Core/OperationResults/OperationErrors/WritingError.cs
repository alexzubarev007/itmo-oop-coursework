namespace Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;

public sealed record WritingError : IFileSystemError
{
    public string Message() => "Unable to write";
}