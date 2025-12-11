namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public interface ICommandParserFactoryLink
{
    ICommandParserFactory? ParseCommandName(string[] commandLineTokens);

    ICommandParserFactoryLink AddNext(ICommandParserFactoryLink factoryLink);
}
