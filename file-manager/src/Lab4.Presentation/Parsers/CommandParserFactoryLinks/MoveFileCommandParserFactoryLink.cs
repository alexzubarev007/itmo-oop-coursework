using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class MoveFileCommandParserFactoryLink : CommandParserFactoryLinkBase
{
    public override ICommandParserFactory? ParseCommandName(string[] commandLineTokens)
    {
        if (commandLineTokens[0] == "file" &&
            commandLineTokens[1] == "move")
        {
            return new MoveFileParserFactory();
        }

        return CallNext(commandLineTokens);
    }
}