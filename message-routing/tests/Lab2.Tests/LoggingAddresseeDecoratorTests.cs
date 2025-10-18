using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class LoggingAddresseeDecoratorTests
{
    [Fact]
    public void Log_WhenMessageAccepted_Written()
    {
        // arrange
        var message = new Message("Random Header", "Random Text", ImportanceLevel.Medium);
        IAddressee addressee = Substitute.For<IAddressee>();
        ILogger logger = Substitute.For<ILogger>();

        var messagesLogger = new LoggingAddresseeDecorator(addressee, logger);

        // act
        messagesLogger.Accept(message);

        // assert
        logger.Received(1).Log($"Message with header:{message.Header} accepted");
        addressee.Received(1).Accept(Arg.Any<Message>());
    }
}