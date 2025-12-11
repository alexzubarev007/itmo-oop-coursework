using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.OperationResults.OperationErrors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystems;

public class FileSystemController
{
    public IFileSystem FileSystem { get; private set; } = new NullFileSystem();

    public void Connect(IFileSystem fileSystem)
    {
        FileSystem = fileSystem;
    }

    public OperationResult Disconnect()
    {
        if (FileSystem is NullFileSystem)
        {
            return new OperationResult.Failure(new DisconnectingError());
        }

        FileSystem = new NullFileSystem();
        return new OperationResult.Success();
    }
}