using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.ShowFileFlagAppliers;

public sealed class WritingModeFlagApplier
    : FlagApplierLinkBase<ShowFileCommandBuilder>
{
    private readonly IWriterLink _writingChain;

    public WritingModeFlagApplier(IWriterLink writingChain)
    {
        _writingChain = writingChain;
    }

    public override bool TryApply(
        ShowFileCommandBuilder builder,
        IEnumerator<string> current)
    {
        if (current.Current != "-m")
        {
            return CallNext(builder, current);
        }

        if (!current.MoveNext())
        {
            return false;
        }

        string mode = current.Current;
        IWriter? writer = _writingChain.GetWriterByMode(mode);

        if (writer == null)
        {
            return false;
        }

        builder.WithWriter(writer);
        return true;
    }
}