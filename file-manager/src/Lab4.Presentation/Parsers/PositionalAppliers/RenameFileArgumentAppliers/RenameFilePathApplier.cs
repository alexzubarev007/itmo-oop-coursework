using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.RenameFileArgumentAppliers;

public sealed class RenameFilePathApplier
    : IPositionalApplier<RenameFileCommandBuilder>
{
    public bool TryApply(RenameFileCommandBuilder builder, string value)
    {
        builder.WithPath(value);
        return true;
    }
}