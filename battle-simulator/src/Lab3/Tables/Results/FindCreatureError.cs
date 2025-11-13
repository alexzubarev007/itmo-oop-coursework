namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.Results;

public sealed record FindCreatureError : ITableError
{
    public string Report() => "No such creature";
}