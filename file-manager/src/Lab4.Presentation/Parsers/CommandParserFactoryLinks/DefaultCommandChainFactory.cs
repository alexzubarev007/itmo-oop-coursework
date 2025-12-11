namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class DefaultCommandChainFactory
    : ICommandChainFactory
{
    public ICommandParserFactoryLink Create()
    {
        return new ConnectCommandParserFactoryLink()
            .AddNext(new DisconnectCommandParserFactoryLink())
            .AddNext(new GoToCommandParserFactoryLink())
            .AddNext(new ShowFileCommandParserFactoryLink())
            .AddNext(new DeleteFileCommandParserFactoryLink())
            .AddNext(new MoveFileCommandParserFactoryLink())
            .AddNext(new TreeListCommandParserFactoryLink())
            .AddNext(new RenameFileCommandParserFactoryLink())
            .AddNext(new CopyFileCommandParserFactoryLink());
    }
}