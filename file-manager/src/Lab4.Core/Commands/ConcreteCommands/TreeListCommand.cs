using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class TreeListCommand : ICommand
{
    public TreeListCommand(int depth)
    {
        Depth = depth;
    }

    public int Depth { get; }

    public FormattingTreeParameters? Parameters { get; set; }

    public IWriter? Writer { get; set; }

    public CommandResult Execute(FileSystemController controller)
    {
        IFileSystem? fileSystem = controller.FileSystem;

        if (fileSystem is null)
        {
            return new CommandResult.Failure(new DisconnectingError());
        }

        var component = new DirectoryFileSystemComponent(fileSystem, controller.ConnectionPath);

        if ((Parameters is null) ||
            Writer is null)
        {
            return new CommandResult.Failure(new WritingError());
        }

        var visitor = new TreeFormattingFileSystemComponentVisitor(Parameters, Depth);

        component.Accept(visitor);

        string treeText = visitor.TreeStringBuilder.ToString();

        Writer.Write(treeText);

        return new CommandResult.Success();
    }
}