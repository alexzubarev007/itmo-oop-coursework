namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks.Defaults;

public sealed class DefaultFileSubChain
    : ICommandChainFactory
{
    public ICommandParserLink Create()
    {
        return new CopyFileCommandParserLink()
            .AddNext(new MoveFileCommandParserLink())
            .AddNext(new RenameFileCommandParserLink())
            .AddNext(new CopyFileCommandParserLink())
            .AddNext(new ShowFileCommandParserLink())
            .AddNext(new DeleteFileCommandParserLink());
    }
}