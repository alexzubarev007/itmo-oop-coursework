using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks.Defaults;

public sealed class DefaultTreeSubChain
    : ICommandChainFactory
{
    public ICommandParserLink Create()
    {
        return new TreeListCommandParserLink(
                new FormattingTreeParameters("*", "$", "|||"),
                new ConsoleWriter())
                   .AddNext(new GoToCommandParserLink());
    }
}