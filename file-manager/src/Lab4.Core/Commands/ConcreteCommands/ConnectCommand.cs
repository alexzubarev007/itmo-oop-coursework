using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.CommandResults.CommandErrors;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

public sealed class ConnectCommand : ICommand
{
    public ConnectCommand(
        string path,
        IFileSystemFactory fileSystemFactory)
    {
        ConnectionPath = path;
        FileSystemFactory = fileSystemFactory;
    }

    public string ConnectionPath { get; }

    public IFileSystemFactory FileSystemFactory { get; }

    public CommandResult Execute(FileSystemController controller)
    {
        IFileSystem fileSystem = FileSystemFactory.Create();

        if (!fileSystem.DirectoryExists(ConnectionPath))
        {
            return new CommandResult.Failure(new NonExistPathError());
        }

        controller.Connect(fileSystem, ConnectionPath);
        return new CommandResult.Success();
    }
}