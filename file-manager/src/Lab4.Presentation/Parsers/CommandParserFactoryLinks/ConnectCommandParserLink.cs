using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class ConnectCommandParserLink : CommandParserLinkBase
{
    public override ICommandParser? ParseCommandName(IEnumerator<string> current)
    {
        if (current.Current == "connect")
        {
            return new ConnectParserFactory().Create();
        }

        return CallNext(current);
    }
}