using Itmo.ObjectOrientedProgramming.Lab2.Addressees;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Topics;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class TopicTests
{
    private class CountingReceivingAddresseeUser : IAddressee
    {
        private readonly User _user;

        public int CallsNumber { get; private set; } = 0;

        public CountingReceivingAddresseeUser(User user)
        {
            _user = user;
        }

        public void Accept(Message message)
        {
            CallsNumber++;
            _user.Accept(message);
        }
    }

    [Fact]
    public void TwoMessages_WhenOneDoesNotFilter_OnlyOneAccepted()
    {
        // arrange
        var message = new Message("Random Header", "Random Text", ImportanceLevel.Low);
        var user = new User();
        var countingAddressee = new CountingReceivingAddresseeUser(user);
        var filterCountingAddressee = new FilterAddresseeProxy(countingAddressee, ImportanceLevel.High);
        Topic topic = new Topic("Simple topic").Add(countingAddressee).Add(filterCountingAddressee);

        // act
        topic.Send(message);

        // assert
        Assert.Equal(1, countingAddressee.CallsNumber);
    }
}