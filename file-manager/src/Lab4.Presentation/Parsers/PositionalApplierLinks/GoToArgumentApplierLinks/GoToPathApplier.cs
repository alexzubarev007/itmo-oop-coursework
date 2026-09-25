using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.GoToArgumentApplierLinks;

public sealed class GoToPathApplier
    : PositionalApplierLinkBase<GoToCommandBuilder>
{
    public override bool TryApply(GoToCommandBuilder builder, IEnumerator<string> current)
    {
        if (!current.MoveNext())
        {
            return false;
        }

        builder.WithPath(current.Current);

        return CallNext(builder, current);
    }
}
