namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class DefaultCommandChainFactory
    : ICommandChainFactory
{
    public ICommandParserLink Create()
    {
        return new ConnectCommandParserLink()
            .AddNext(new DisconnectCommandParserLink())
            .AddNext(new TreeCommandParserLink())
            .AddNext(new FileCommandParserLink());
    }
}