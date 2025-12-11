using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.ConnectFlagAppliers;

public sealed class FileSystemModeFlagApplier
    : FlagApplierLinkBase<ConnectCommandBuilder>
{
    public override bool TryApply(
        ConnectCommandBuilder builder,
        string name,
        string value)
    {
        if (name == "-m")
        {
            builder.WithMode(value);
            return true;
        }

        return CallNext(builder, name, value);
    }
}