using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class LoggingAddresseeDecorator : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly Action<string> _logger;

    public LoggingAddresseeDecorator(IAddressee addressee, Action<string> logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void Accept(Message message)
    {
        _logger?.Invoke($"Message with header:{message.Header} accepted");
        _addressee.Accept(message);
    }
}