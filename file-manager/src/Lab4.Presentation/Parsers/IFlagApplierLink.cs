using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;

public interface IFlagApplierLink<TCommandBuilder>
    where TCommandBuilder : ICommandBuilder
{
    bool TryApply(TCommandBuilder commandBuilder, string name, string value);

    IFlagApplierLink<TCommandBuilder> AddNext(IFlagApplierLink<TCommandBuilder> link);
}