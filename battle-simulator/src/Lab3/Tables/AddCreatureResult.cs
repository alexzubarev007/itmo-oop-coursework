namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public abstract record AddCreatureResult
{
    private AddCreatureResult() { }

    public sealed record Success : AddCreatureResult;

    public sealed record Failure : AddCreatureResult;
}