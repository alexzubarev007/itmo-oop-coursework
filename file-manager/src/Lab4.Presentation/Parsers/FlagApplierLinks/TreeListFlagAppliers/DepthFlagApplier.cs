using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.TreeListFlagAppliers;

public sealed class DepthFlagApplier : FlagApplierLinkBase<TreeListCommandBuilder>
{
    public override bool TryApply(
        TreeListCommandBuilder builder,
        string name,
        string value)
    {
        if (name != "-d")
        {
            return CallNext(builder, name, value);
        }

        if (!int.TryParse(value, out int depth) ||
            depth < 0)
        {
            return false;
        }

        builder.WithDepth(depth);
        return true;
    }
}