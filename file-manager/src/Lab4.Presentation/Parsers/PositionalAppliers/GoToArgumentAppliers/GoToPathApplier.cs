using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.GoToArgumentAppliers;

public sealed class GoToPathApplier
    : IPositionalApplier<GoToCommandBuilder>
{
    public bool TryApply(GoToCommandBuilder builder, string value)
    {
        builder.WithPath(value);
        return true;
    }
}
