using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class GoToCommandParserLink : CommandParserLinkBase
{
    public override ICommandParser? ParseCommandName(IEnumerator<string> current)
    {
        if (current.Current == "goto")
        {
            return new GoToParserFactory().Create();
        }

        return CallNext(current);
    }
}