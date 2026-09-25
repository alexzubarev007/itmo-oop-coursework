namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks.Defaults;

public sealed class DefaultCommandChainFactory
    : ICommandChainFactory
{
    public ICommandParserLink Create()
    {
        ICommandParserLink defaultFileSubChain = new DefaultFileSubChain().Create();
        ICommandParserLink defaultTreeSubChain = new DefaultTreeSubChain().Create();

        return new ConnectCommandParserLink()
            .AddNext(new DisconnectCommandParserLink())
            .AddNext(new TreeCommandParserLink(defaultTreeSubChain))
            .AddNext(new FileCommandParserLink(defaultFileSubChain));
    }
}