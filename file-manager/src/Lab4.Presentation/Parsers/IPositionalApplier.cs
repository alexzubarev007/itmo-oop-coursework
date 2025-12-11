using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public interface IPositionalApplier<TCommandBuilder>
    where TCommandBuilder : ICommandBuilder
{
    bool TryApply(TCommandBuilder builder, string value);
}