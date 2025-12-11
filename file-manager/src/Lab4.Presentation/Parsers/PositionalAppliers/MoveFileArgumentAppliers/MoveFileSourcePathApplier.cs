using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.MoveFileArgumentAppliers;

public sealed class MoveFileSourcePathApplier
    : IPositionalApplier<MoveFileCommandBuilder>
{
    public bool TryApply(MoveFileCommandBuilder builder, string value)
    {
        builder.WithSourcePath(value);
        return true;
    }
}