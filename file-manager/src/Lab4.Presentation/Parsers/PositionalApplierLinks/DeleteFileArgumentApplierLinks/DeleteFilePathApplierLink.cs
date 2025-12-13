using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks.DeleteFileArgumentApplierLinks;

public sealed class DeleteFilePathApplierLink
    : PositionalApplierLinkBase<DeleteFileCommandBuilder>
{
    public override bool TryApply(DeleteFileCommandBuilder builder, IEnumerator<string> current)
    {
        if (!current.MoveNext())
        {
            return false;
        }

        builder.WithPath(current.Current);
        return CallNext(builder, current);
    }
}