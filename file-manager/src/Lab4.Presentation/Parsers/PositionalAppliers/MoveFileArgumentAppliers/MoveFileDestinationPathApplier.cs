using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.MoveFileArgumentAppliers;

public sealed class MoveFileDestinationPathApplier
    : IPositionalApplier<MoveFileCommandBuilder>
{
    public bool TryApply(MoveFileCommandBuilder builder, string value)
    {
        builder.WithDestinationPath(value);
        return true;
    }
}