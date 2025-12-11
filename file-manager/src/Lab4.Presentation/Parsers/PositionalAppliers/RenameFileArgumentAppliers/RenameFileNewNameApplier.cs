using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.RenameFileArgumentAppliers;

public sealed class RenameFileNewNameApplier
    : IPositionalApplier<RenameFileCommandBuilder>
{
    public bool TryApply(RenameFileCommandBuilder builder, string value)
    {
        builder.WithNewName(value);
        return true;
    }
}