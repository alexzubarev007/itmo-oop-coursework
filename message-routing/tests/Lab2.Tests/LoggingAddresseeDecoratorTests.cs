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
        int logWrittenCount = 0;
        Action<string> logger = writer => logWrittenCount++;

        var messagesLogger = new LoggingAddresseeDecorator(addressee, logger);

        // act
        messagesLogger.Accept(message);

        // assert
        Assert.Equal(1, logWrittenCount);
        addressee.Received(1).Accept(Arg.Any<Message>());
    }
}