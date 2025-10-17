using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class UserTests
{
    [Fact]
    public void ReadStatus_WhenMessageAcceptedFirstly_Unread()
    {
        // arrange
        var message = new Message("Random Header", "Random Text", ImportanceLevel.Low);
        var user = new User();

        // act
        user.Accept(message);

        // assert
        Assert.Equal(ReadStatus.Unread, user.GetReadStatus(message));
    }

    [Fact]
    public void ReadStatus_WhenMessageMarkedAsRead_Read()
    {
        // arrange
        var message = new Message("Random Header", "Random Text", ImportanceLevel.Low);
        var user = new User();

        // act
        user.Accept(message);

        ReadStatus status = user.GetReadStatus(message);

        user.MarkAsRead(message);

        // assert
        Assert.Equal(ReadStatus.Unread, status);
        Assert.Equal(ReadStatus.Read, user.GetReadStatus(message));
    }

    [Fact]
    public void MarkAsReadMessage_WhenMessageMarkedAsReadAlready_Failes()
    {
        // arrange
        var message = new Message("Random Header", "Random Text", ImportanceLevel.Low);
        var user = new User();

        // act
        user.Accept(message);
        user.MarkAsRead(message);

        // assert
        Exception exception = Assert.Throws<InvalidOperationException>(() => user.MarkAsRead(message));
        Assert.Equal("Try to mark as read already read message", exception.Message);
    }
}