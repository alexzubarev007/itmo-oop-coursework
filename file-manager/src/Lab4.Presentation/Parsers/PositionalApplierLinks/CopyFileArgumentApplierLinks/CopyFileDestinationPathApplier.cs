using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.CopyFileArgumentApplierLinks;

public sealed class CopyFileDestinationPathApplier
    : PositionalApplierLinkBase<CopyFileCommandBuilder>
{
    public override bool TryApply(CopyFileCommandBuilder builder, IEnumerator<string> current)
    {
        if (!current.MoveNext())
        {
            return false;
        }

        builder.WithDestinationPath(current.Current);
        return CallNext(builder, current);
    }
}