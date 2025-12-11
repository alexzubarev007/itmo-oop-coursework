using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;

public record OperationResult
{
    private OperationResult() { }

    public sealed record Success : OperationResult;

    public sealed record Failure(IFileSystemError Error) : OperationResult;
}