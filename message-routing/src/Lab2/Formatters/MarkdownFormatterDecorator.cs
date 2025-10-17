using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkdownFormatterDecorator : IFormatter
{
    private readonly IFormatter _formatter;

    public MarkdownFormatterDecorator(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void WriteHeader(Message message)
    {
        string formattedHeader = $"# {message.Header}";
        _formatter.WriteBody(new Message(formattedHeader, message.Body, message.Importance));
    }

    public void WriteBody(Message message)
    {
        string formattedBody = $"**{message.Body}**";
        _formatter.WriteBody(new Message(message.Header, formattedBody, message.Importance));
    }
}