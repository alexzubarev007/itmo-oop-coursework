using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class CopyFileCommandParserLink : CommandParserLinkBase
{
    public override ICommandParser? ParseCommandName(IEnumerator<string> current)
    {
        if (current.Current == "copy")
        {
            return new CopyFileParserFactory().Create();
        }

        return CallNext(current);
    }
}