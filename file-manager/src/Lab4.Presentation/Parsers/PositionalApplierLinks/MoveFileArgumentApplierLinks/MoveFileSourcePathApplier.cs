using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.MoveFileArgumentApplierLinks;

public sealed class MoveFileSourcePathApplier
    : PositionalApplierLinkBase<MoveFileCommandBuilder>
{
    public override bool TryApply(MoveFileCommandBuilder builder, IEnumerator<string> current)
    {
        if (!current.MoveNext())
        {
            return false;
        }

        builder.WithSourcePath(current.Current);
        return CallNext(builder, current);
    }
}