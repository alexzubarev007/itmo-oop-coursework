using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class RenameFileCommandParserFactoryLink : CommandParserFactoryLinkBase
{
    public override ICommandParserFactory? ParseCommandName(string[] commandLineTokens)
    {
        if (commandLineTokens[0] == "file" &&
            commandLineTokens[1] == "rename")
        {
            return new RenameFileParserFactory();
        }

        return CallNext(commandLineTokens);
    }
}