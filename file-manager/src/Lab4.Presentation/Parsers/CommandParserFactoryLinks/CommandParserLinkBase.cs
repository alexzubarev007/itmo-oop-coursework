namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public abstract class CommandParserLinkBase : ICommandParserLink
{
    private ICommandParserLink? _next;

    public abstract ICommandParser? ParseCommandName(IEnumerator<string> current);

    public ICommandParserLink AddNext(ICommandParserLink parserLink)
    {
        if (_next is null)
        {
            _next = parserLink;
        }
        else
        {
            _next.AddNext(parserLink);
        }

        return this;
    }

    protected ICommandParser? CallNext(IEnumerator<string> current)
    {
        return _next?.ParseCommandName(current)
               ?? null;
    }
}