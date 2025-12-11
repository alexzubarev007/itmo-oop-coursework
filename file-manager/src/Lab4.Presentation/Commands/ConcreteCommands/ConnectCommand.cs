using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.Factories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems.FileSystemFactoryLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;

public sealed class ConnectCommand : ICommand
{
    public ConnectCommand(string path, string mode)
    {
        ConnectionPath = path;
        Mode = mode;
        FileSystemRegimeChain = new LocalFileSystemFactoryLink();
    }

    public string ConnectionPath { get; }

    public string Mode { get; }

    public IFileSystemFactoryLink FileSystemRegimeChain { get; set; }

    public OperationResult Execute(FileSystemController controller)
    {
        IFileSystemFactory? factory = FileSystemRegimeChain
                                     .GetFileSystemByMode(Mode);
        if (factory == null)
        {
            return new OperationResult.Failure(new CannotSelectFileSystemError());
        }

        IFileSystem fileSystem = factory.Create(ConnectionPath);

        controller.Connect(fileSystem);
        return new OperationResult.Success();
    }
}