using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.MoveFileArgumentAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class MoveFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positional = new List<IPositionalApplier<MoveFileCommandBuilder>>
        {
            new MoveFileSourcePathApplier(),
            new MoveFileDestinationPathApplier(),
        };

        IFlagApplierLink<MoveFileCommandBuilder>? flagChain = null;

        return new MoveFileCommandParser(positional, flagChain);
    }
}