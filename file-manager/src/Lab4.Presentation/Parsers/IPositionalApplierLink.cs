using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public interface IPositionalApplierLink<TCommandBuilder>
    where TCommandBuilder : ICommandBuilder
{
    bool TryApply(TCommandBuilder builder, IEnumerator<string> current);

    IPositionalApplierLink<TCommandBuilder> AddNext(IPositionalApplierLink<TCommandBuilder> link);
}