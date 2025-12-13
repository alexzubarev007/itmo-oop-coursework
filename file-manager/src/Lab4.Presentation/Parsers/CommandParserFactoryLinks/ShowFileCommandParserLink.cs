using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class ShowFileCommandParserLink : CommandParserLinkBase
{
    public override ICommandParser? ParseCommandName(IEnumerator<string> current)
    {
        if (current.Current == "show")
        {
            return new ShowFileParserFactory().Create();
        }

        return CallNext(current);
    }
}