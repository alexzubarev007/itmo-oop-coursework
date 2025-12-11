using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Components.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

public sealed class TreeListCommand : ICommand
{
    public TreeListCommand(int depth)
    {
        Depth = depth;
    }

    public int Depth { get; }

    public FormattingTreeParameters? Parameters { get; set; }

    public IWriter? Writer { get; set; }

    public OperationResult Execute(FileSystemController controller)
    {
        IFileSystemComponent? component = controller.FileSystem.GetComponent();

        if (component is null)
        {
            return new OperationResult.Failure(new NonExistPathError());
        }

        if ((Parameters is null) ||
            Writer is null)
        {
            return new OperationResult.Failure(new WritingError());
        }

        var visitor = new TreeFormattingFileSystemComponentVisitor(Parameters, Depth);

        component.Accept(visitor);

        string treeText = visitor.TreeStringBuilder.ToString();

        Writer.Write(treeText);

        return new OperationResult.Success();
    }
}