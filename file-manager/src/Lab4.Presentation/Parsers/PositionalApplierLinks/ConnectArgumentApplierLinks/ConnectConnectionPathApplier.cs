using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.ConnectArgumentApplierLinks;

public sealed class ConnectConnectionPathApplier
    : PositionalApplierLinkBase<ConnectCommandBuilder>
{
    public override bool TryApply(ConnectCommandBuilder builder, IEnumerator<string> current)
    {
        if (!current.MoveNext())
        {
            return false;
        }

        builder.WithConnectionPath(current.Current);
        return CallNext(builder, current);
    }
}