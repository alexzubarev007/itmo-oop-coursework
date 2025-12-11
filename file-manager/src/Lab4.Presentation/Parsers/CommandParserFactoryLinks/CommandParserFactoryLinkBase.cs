namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public abstract class CommandParserFactoryLinkBase : ICommandParserFactoryLink
{
    private ICommandParserFactoryLink? _next;

    public abstract ICommandParserFactory? ParseCommandName(string[] commandLineTokens);

    public ICommandParserFactoryLink AddNext(ICommandParserFactoryLink factoryLink)
    {
        if (_next is null)
        {
            _next = factoryLink;
        }
        else
        {
            _next.AddNext(factoryLink);
        }

        return this;
    }

    protected ICommandParserFactory? CallNext(string[] commandLineTokens)
    {
        return _next?.ParseCommandName(commandLineTokens)
               ?? null;
    }
}