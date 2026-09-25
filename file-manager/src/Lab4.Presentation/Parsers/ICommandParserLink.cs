namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public interface ICommandParserLink
{
    ICommandParser? ParseCommandName(IEnumerator<string> current);

    ICommandParserLink AddNext(ICommandParserLink parserLink);
}
