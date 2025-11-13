namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.Results;

public sealed record AddCreatureError : ITableError
{
    public string Report() => "Try to add creature breaking limit";
}