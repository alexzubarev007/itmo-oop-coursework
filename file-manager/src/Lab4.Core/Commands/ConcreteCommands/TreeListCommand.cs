using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class TreeListCommand : ICommand
{
    private readonly FormattingTreeParameters _parameters;

    private readonly IWriter _writer;

    public TreeListCommand(int depth, IWriter writer, FormattingTreeParameters parameters)
    {
        Depth = depth;
        _parameters = parameters;
        _writer = writer;
    }

    public int Depth { get; }

    public CommandResult Execute(FileSystemController controller)
    {
        IFileSystem? fileSystem = controller.FileSystem;

        if (fileSystem is null)
        {
            return new CommandResult.Failure(new DisconnectingError());
        }

        var component = new DirectoryFileSystemComponent(fileSystem, controller.ConnectionPath);

        var visitor = new TreeFormattingFileSystemComponentVisitor(_parameters, Depth);

        component.Accept(visitor);

        string treeText = visitor.TreeStringBuilder.ToString();

        _writer.Write(treeText);

        return new CommandResult.Success();
    }
}