using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

public sealed class ShowFileCommand : ICommand
{
    public ShowFileCommand(string path, string writingMode)
    {
        FilePath = path;
        WritingMode = writingMode;
        WritingRegimeChain = new ConsoleWriterLink();
    }

    public string FilePath { get; }

    public string WritingMode { get; }

    public IWriterLink WritingRegimeChain { get; set; }

    public OperationResult Execute(FileSystemController controller)
    {
        IWriter? writer = WritingRegimeChain.GetWriterByMode(WritingMode);

        if (writer is null)
        {
            return new OperationResult.Failure(new WritingError());
        }

        return controller.FileSystem.GetFileContent(FilePath, writer);
    }
}