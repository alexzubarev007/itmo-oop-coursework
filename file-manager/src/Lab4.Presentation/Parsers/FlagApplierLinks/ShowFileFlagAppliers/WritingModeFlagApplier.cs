using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.ShowFileFlagAppliers;

public sealed class WritingModeFlagApplier
    : FlagApplierLinkBase<ShowFileCommandBuilder>
{
    public override bool TryApply(
        ShowFileCommandBuilder builder,
        string name,
        string value)
    {
        if (name == "-m")
        {
            builder.WithWritingMode(value);
            return true;
        }

        return CallNext(builder, name, value);
    }
}