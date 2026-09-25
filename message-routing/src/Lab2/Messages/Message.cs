namespace Itmo.ObjectOrientedProgramming.Lab2.Messages;

public class Message
{
    public string Header { get; }

    public string Body { get; }

    public ImportanceLevel Importance { get; }

    public Message(string header, string body, ImportanceLevel importance)
    {
        if (string.IsNullOrWhiteSpace(header))
        {
            throw new ArgumentNullException(nameof(header));
        }

        if (string.IsNullOrWhiteSpace(body))
        {
            throw new ArgumentNullException(nameof(body));
        }

        Header = header;
        Body = body;
        Importance = importance;
    }
}