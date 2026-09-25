using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class ShowFileCommand : ICommand
{
    public ShowFileCommand(string path, IWriter writer)
    {
        FilePath = path;
        Writer = writer;
    }

    public string FilePath { get; }

    public IWriter Writer { get; }

    public CommandResult Execute(FileSystemController controller)
    {
        IFileSystem? fileSystem = controller.FileSystem;

        if (fileSystem is null)
        {
            return new CommandResult.Failure(new DisconnectingError());
        }

        string fullPath = fileSystem
            .GetFullPath(controller.ConnectionPath, controller.LocalPath, FilePath);

        if (!fileSystem.FileExists(fullPath))
        {
            return new CommandResult.Failure(new NonExistPathError());
        }

        if (!fullPath.StartsWith(controller.ConnectionPath))
        {
            return new CommandResult.Failure(new OutOfConnectionPathError());
        }

        string content = fileSystem.GetFileContent(fullPath);

        Writer.Write(content);

        return new CommandResult.Success();
    }
}