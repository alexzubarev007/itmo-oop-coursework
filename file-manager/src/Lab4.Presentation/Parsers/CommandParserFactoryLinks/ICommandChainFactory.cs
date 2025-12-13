namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;

public interface ICommandChainFactory
{
    ICommandParserLink Create();
}