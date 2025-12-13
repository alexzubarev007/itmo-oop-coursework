using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.CopyFileArgumentApplierLinks;

public sealed class CopyFileSourcePathApplier
    : PositionalApplierLinkBase<CopyFileCommandBuilder>
{
    public override bool TryApply(CopyFileCommandBuilder builder, IEnumerator<string> current)
    {
        if (!current.MoveNext())
        {
            return false;
        }

        builder.WithSourcePath(current.Current);
        return CallNext(builder, current);
    }
}