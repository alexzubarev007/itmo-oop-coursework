using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks.Defaults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var parameters = new FormattingTreeParameters("*", "$", "---");
        var treeWriter = new ConsoleWriter();

        ICommandParserLink fileSubChain = new DefaultFileSubChain().Create();

        ICommandParserLink treeSubChain = new TreeListCommandParserLink(parameters, treeWriter)
                                              .AddNext(new GoToCommandParserLink());

        ICommandParserLink commandChain = new ConnectCommandParserLink()
                                                .AddNext(new FileCommandParserLink(fileSubChain))
                                                .AddNext(new TreeCommandParserLink(treeSubChain))
                                                .AddNext(new DisconnectCommandParserLink());

        var parser = new Parser(commandChain);
        var appRunner = new AppRunner(parser);

        appRunner.Run();
    }
}