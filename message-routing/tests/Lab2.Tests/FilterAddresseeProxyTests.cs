using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FilterAddresseeProxyTests
{
    [Fact]
    public void Message_WhenImportanceIsNotEnough_NotAccepted()
    {
        // arrange
        var message = new Message("Random Header", "Random Text", ImportanceLevel.Medium);
        IAddressee addressee = Substitute.For<IAddressee>();
        var messagesFilter = new FilterAddresseeProxy(addressee, ImportanceLevel.High);

        // act
        messagesFilter.Accept(message);

        // assert
        addressee.DidNotReceive().Accept(Arg.Any<Message>());
    }
}