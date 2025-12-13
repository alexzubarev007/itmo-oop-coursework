using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.FlagApplierLinks.ConnectFlagAppliers;

public sealed class FileSystemModeFlagApplier
    : FlagApplierLinkBase<ConnectCommandBuilder>
{
    private readonly IFileSystemFactoryLink _filesystemChain;

    public FileSystemModeFlagApplier(IFileSystemFactoryLink filesystemChain)
    {
        _filesystemChain = filesystemChain;
    }

    public override bool TryApply(
        ConnectCommandBuilder builder,
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

        IFileSystemFactory? factory = _filesystemChain.GetFileSystemByMode(mode);

        if (factory == null)
        {
            return false;
        }

        builder.WithFileSystemFactory(factory);
        return true;
    }
}