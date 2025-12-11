using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.RenameFileArgumentAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers.Factories;

public sealed class RenameFileParserFactory : ICommandParserFactory
{
    public ICommandParser Create()
    {
        var positional = new List<IPositionalApplier<RenameFileCommandBuilder>>
        {
            new RenameFilePathApplier(),
            new RenameFileNewNameApplier(),
        };

        IFlagApplierLink<RenameFileCommandBuilder>? flagChain = null;

        return new RenameFileCommandParser(positional, flagChain);
    }
}