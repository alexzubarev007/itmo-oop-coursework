using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public interface IFlagApplierLink<TCommandBuilder>
    where TCommandBuilder : ICommandBuilder
{
    bool TryApply(TCommandBuilder commandBuilder, IEnumerator<string> current);

    IFlagApplierLink<TCommandBuilder> AddNext(IFlagApplierLink<TCommandBuilder> link);
}