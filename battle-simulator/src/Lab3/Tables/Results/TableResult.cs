namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.Results;

public abstract record TableResult
{
    private TableResult() { }

    public sealed record Success : TableResult;

    public sealed record Failure(ITableError Error) : TableResult;
}