using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.RenameFileArgumentApplierLinks;

public sealed class RenameFilePathApplier
    : PositionalApplierLinkBase<RenameFileCommandBuilder>
{
    public override bool TryApply(RenameFileCommandBuilder builder, IEnumerator<string> current)
    {
        if (!current.MoveNext())
        {
            return false;
        }

        builder.WithPath(current.Current);
        return CallNext(builder, current);
    }
}