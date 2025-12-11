using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public class Parser
{
    private readonly ICommandParserFactoryLink _commandsChain;

    public Parser(ICommandParserFactoryLink commandsChain)
    {
        _commandsChain = commandsChain;
    }

    public ParsingResult Parse(string commandLine)
    {
        string[] tokens = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        ICommandParserFactory? commandParserFactory = _commandsChain.ParseCommandName(tokens);

        if (commandParserFactory is null)
        {
            return new ParsingResult.Failure(new UnknownCommandError());
        }

        ICommandParser commandParser = commandParserFactory.Create();

        return commandParser.Parse(tokens);
    }
}