namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public interface ICommandChainFactory
{
    ICommandParserFactoryLink Create();
}