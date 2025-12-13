using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.ShowFileArgumentApplierLinks;

public sealed class ShowFilePathApplier
    : PositionalApplierLinkBase<ShowFileCommandBuilder>
{
    public override bool TryApply(ShowFileCommandBuilder builder, IEnumerator<string> current)
    {
        if (!current.MoveNext())
        {
            return false;
        }

        builder.WithPath(current.Current);
        return CallNext(builder, current);
    }
}