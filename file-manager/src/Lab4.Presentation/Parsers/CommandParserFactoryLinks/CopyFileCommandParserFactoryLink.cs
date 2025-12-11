using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class CopyFileCommandParserFactoryLink : CommandParserFactoryLinkBase
{
    public override ICommandParserFactory? ParseCommandName(string[] commandLineTokens)
    {
        if ((commandLineTokens[0] == "file") &&
             (commandLineTokens[1] == "copy"))
        {
            return new CopyFileParserFactory();
        }

        return CallNext(commandLineTokens);
    }
}