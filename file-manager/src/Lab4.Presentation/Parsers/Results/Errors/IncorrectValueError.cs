namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

public sealed record IncorrectValueError : IParsingError
{
    public string Message() => "Value of argument is incorrect.";
}