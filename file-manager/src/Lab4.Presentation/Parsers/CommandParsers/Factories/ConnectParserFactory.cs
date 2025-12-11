using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.ConnectFlagAppliers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.ConnectArgumentAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class ConnectParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positional = new List<IPositionalApplier<ConnectCommandBuilder>>()
        {
            new ConnectConnectionPathApplier(),
        };

        var flagChain = new FileSystemModeFlagApplier();

        return new ConnectCommandParser(positional, flagChain);
    }
}