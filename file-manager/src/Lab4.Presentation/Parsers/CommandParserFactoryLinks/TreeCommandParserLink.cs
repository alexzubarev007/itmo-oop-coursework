namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class TreeCommandParserLink : CommandParserLinkBase
{
    private readonly ICommandParserLink _subChain;

    public TreeCommandParserLink(ICommandParserLink subChain)
    {
        _subChain = subChain;
    }

    public override ICommandParser? ParseCommandName(IEnumerator<string> current)
    {
        if (current.Current == "tree")
        {
            if (!current.MoveNext())
            {
                return null;
            }

            return _subChain.ParseCommandName(current);
        }

        return CallNext(current);
    }
}