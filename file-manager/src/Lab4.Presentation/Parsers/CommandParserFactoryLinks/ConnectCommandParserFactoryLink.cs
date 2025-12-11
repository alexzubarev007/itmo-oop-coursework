using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class ConnectCommandParserFactoryLink : CommandParserFactoryLinkBase
{
    public override ICommandParserFactory? ParseCommandName(string[] commandLineTokens)
    {
        if (commandLineTokens[0] == "connect")
        {
            return new ConnectParserFactory();
        }

        return CallNext(commandLineTokens);
    }
}