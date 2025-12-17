using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.PositionalApplierLinks;

public abstract class PositionalApplierLinkBase<TCommandBuilder>
    : IPositionalApplierLink<TCommandBuilder>
    where TCommandBuilder : ICommandBuilder
{
    private IPositionalApplierLink<TCommandBuilder>? _next;

    public abstract bool TryApply(TCommandBuilder builder, IEnumerator<string> current);

    public IPositionalApplierLink<TCommandBuilder> AddNext(IPositionalApplierLink<TCommandBuilder> link)
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
               ?? true;
    }
}