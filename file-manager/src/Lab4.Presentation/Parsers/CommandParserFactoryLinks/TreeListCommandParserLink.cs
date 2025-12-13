using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class TreeListCommandParserLink : CommandParserLinkBase
{
    public override ICommandParser? ParseCommandName(IEnumerator<string> current)
    {
        if (current.Current == "list")
        {
            return new TreeListParserFactory().Create();
        }

        return CallNext(current);
    }
}