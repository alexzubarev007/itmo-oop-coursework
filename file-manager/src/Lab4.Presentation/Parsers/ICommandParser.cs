using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public interface ICommandParser
{
    ParsingResult Parse(IEnumerator<string> current);
}