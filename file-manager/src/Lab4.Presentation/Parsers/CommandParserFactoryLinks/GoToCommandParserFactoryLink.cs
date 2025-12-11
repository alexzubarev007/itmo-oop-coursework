using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class GoToCommandParserFactoryLink : CommandParserFactoryLinkBase
{
    public override ICommandParserFactory? ParseCommandName(string[] commandLineTokens)
    {
        if (commandLineTokens[0] == "tree" &&
            commandLineTokens[1] == "goto")
        {
            return new GoToParserFactory();
        }

        return CallNext(commandLineTokens);
    }
}