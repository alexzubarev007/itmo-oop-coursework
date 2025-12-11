using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.CopyFileArgumentAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class CopyFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positional = new List<IPositionalApplier<CopyFileCommandBuilder>>()
        {
            new CopyFileSourcePathApplier(),
            new CopyFileDestinationPathApplier(),
        };

        IFlagApplierLink<CopyFileCommandBuilder>? flagChain = null;

        return new CopyFileCommandParser(positional, flagChain);
    }
}