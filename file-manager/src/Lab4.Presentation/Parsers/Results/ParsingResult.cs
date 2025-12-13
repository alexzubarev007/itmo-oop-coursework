using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

public record ParsingResult
{
    private ParsingResult() { }

    public sealed record Success(ICommand Command) : ParsingResult;

    public sealed record Failure(IParsingError Error) : ParsingResult;
}