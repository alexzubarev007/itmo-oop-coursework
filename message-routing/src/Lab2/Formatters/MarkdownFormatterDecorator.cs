namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkdownFormatterDecorator : IFormatter
{
    private readonly IFormatter _formatter;

    public MarkdownFormatterDecorator(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void WriteHeader(string header)
    {
        string formattedHeader = $"# {header}";
        _formatter.WriteBody(formattedHeader);
    }

    public void WriteBody(string body)
    {
        string formattedBody = $"**{body}**";
        _formatter.WriteBody(formattedBody);
    }
}