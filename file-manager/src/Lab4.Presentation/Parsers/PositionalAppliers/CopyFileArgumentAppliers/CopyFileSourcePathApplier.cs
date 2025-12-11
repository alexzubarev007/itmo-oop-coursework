using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.CopyFileArgumentAppliers;

public sealed class CopyFileSourcePathApplier
    : IPositionalApplier<CopyFileCommandBuilder>
{
    public bool TryApply(CopyFileCommandBuilder builder, string value)
    {
        builder.WithSourcePath(value);
        return true;
    }
}