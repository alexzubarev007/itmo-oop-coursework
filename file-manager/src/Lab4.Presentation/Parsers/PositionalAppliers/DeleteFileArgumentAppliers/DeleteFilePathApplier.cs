using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalAppliers.DeleteFileArgumentAppliers;

public sealed class DeleteFilePathApplier
    : IPositionalApplier<DeleteFileCommandBuilder>
{
    public bool TryApply(DeleteFileCommandBuilder builder, string value)
    {
        builder.WithPath(value);
        return true;
    }
}