namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

public sealed record UninitializingError : IParsingError
{
    public string Message() => "Some parameters of command are uninitialized.";
}