using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.MoveFileArgumentApplierLinks;

public sealed class MoveFileDestinationPathApplier
    : PositionalApplierLinkBase<MoveFileCommandBuilder>
{
    public override bool TryApply(MoveFileCommandBuilder builder, IEnumerator<string> current)
    {
        if (!current.MoveNext())
        {
            return false;
        }

        builder.WithDestinationPath(current.Current);
        return CallNext(builder, current);
    }
}