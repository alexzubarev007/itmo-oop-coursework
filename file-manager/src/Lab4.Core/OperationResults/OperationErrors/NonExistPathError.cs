namespace Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;

public sealed record NonExistPathError : IFileSystemError
{
    public string Message() => "The path doesn't exist";
}