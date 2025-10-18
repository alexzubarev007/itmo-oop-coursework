namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileFormatter : IFormatter
{
    private readonly string _path;

    public FileFormatter(string path)
    {
        _path = path;
    }

    public void WriteHeader(string header)
    {
        File.AppendAllText(_path, header + "\n");
    }

    public void WriteBody(string body)
    {
        File.AppendAllText(_path, body + "\n");
    }
}