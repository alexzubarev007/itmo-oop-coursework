using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.ShowFileArgumentAppliers;

public sealed class ShowFilePathApplier
    : IPositionalApplier<ShowFileCommandBuilder>
{
    public bool TryApply(ShowFileCommandBuilder builder, string value)
    {
        builder.WithPath(value);
        return true;
    }
}