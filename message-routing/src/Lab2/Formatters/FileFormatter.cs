using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileFormatter : IFormatter
{
    private readonly string _path;

    public FileFormatter(string path)
    {
        _path = path;
    }

    public void WriteHeader(Message message)
    {
        File.AppendAllText(_path, message.Header + "\n");
    }

    public void WriteBody(Message message)
    {
        File.AppendAllText(_path, message.Body + "\n");
    }
}