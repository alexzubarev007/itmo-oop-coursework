using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks;

public abstract class FlagApplierLinkBase<TCommandBuilder>
    : IFlagApplierLink<TCommandBuilder>
     where TCommandBuilder : ICommandBuilder
{
    private IFlagApplierLink<TCommandBuilder>? _next;

    public abstract bool TryApply(TCommandBuilder builder, IEnumerator<string> current);

    public IFlagApplierLink<TCommandBuilder> AddNext(IFlagApplierLink<TCommandBuilder> link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected bool CallNext(
        TCommandBuilder builder,
        IEnumerator<string> current)
    {
        return _next?.TryApply(builder, current)
               ?? false;
    }
}