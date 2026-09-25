namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

public sealed record UnknownCommandError : IParsingError
{
    public string Message() => "Unknown command.";
}