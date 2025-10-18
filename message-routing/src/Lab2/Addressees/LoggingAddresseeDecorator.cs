using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class LoggingAddresseeDecorator : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public LoggingAddresseeDecorator(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void Accept(Message message)
    {
        _logger.Log($"Message with header:{message.Header} accepted");
        _addressee.Accept(message);
    }
}