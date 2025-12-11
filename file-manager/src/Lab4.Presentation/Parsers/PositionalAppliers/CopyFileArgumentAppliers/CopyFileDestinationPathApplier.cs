using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.CopyFileArgumentAppliers;

public sealed class CopyFileDestinationPathApplier
    : IPositionalApplier<CopyFileCommandBuilder>
{
    public bool TryApply(CopyFileCommandBuilder builder, string value)
    {
        builder.WithDestinationPath(value);
        return true;
    }
}