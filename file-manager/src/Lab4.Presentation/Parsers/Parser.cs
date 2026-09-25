using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class Parser
{
    private readonly ICommandParserLink _commandsChain;

    public Parser(ICommandParserLink commandsChain)
    {
        _commandsChain = commandsChain;
    }

    public ParsingResult Parse(string commandLine)
    {
        string[] tokens = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        IEnumerator<string> current = tokens.AsEnumerable().GetEnumerator();

        current.MoveNext();

        ICommandParser? commandParser = _commandsChain.ParseCommandName(current);

        if (commandParser is null)
        {
            return new ParsingResult.Failure(new UnknownCommandError());
        }

        return commandParser.Parse(current);
    }
}