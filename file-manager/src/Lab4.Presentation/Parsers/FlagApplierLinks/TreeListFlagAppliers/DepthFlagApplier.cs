using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.TreeListFlagAppliers;

public sealed class DepthFlagApplier : FlagApplierLinkBase<TreeListCommandBuilder>
{
    public override bool TryApply(
        TreeListCommandBuilder builder,
        IEnumerator<string> current)
    {
        if (current.Current != "-d")
        {
            return CallNext(builder, current);
        }

        if (!current.MoveNext())
        {
            return false;
        }

        string value = current.Current;

        if (!int.TryParse(value, out int depth) ||
            depth < 0)
        {
            return false;
        }

        builder.WithDepth(depth);
        return true;
    }
}