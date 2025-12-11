using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.ConnectArgumentAppliers;

public sealed class ConnectConnectionPathApplier
    : IPositionalApplier<ConnectCommandBuilder>
{
    public bool TryApply(ConnectCommandBuilder builder, string value)
    {
        builder.WithConnectionPath(value);
        return true;
    }
}