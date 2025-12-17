using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public sealed class TreeListCommandParserLink : CommandParserLinkBase
{
    private readonly FormattingTreeParameters _parameters;
    private readonly IWriter _writer;

    public TreeListCommandParserLink(FormattingTreeParameters parameters, IWriter writer)
    {
        _parameters = parameters;
        _writer = writer;
    }

    public override ICommandParser? ParseCommandName(IEnumerator<string> current)
    {
        if (current.Current == "list")
        {
            return new TreeListParserFactory(_parameters, _writer).Create();
        }

        return CallNext(current);
    }
}