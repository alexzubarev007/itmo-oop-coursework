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

        ReadStatus? status = user.GetReadStatus(message);

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

        UserResult firstResult = user.MarkAsRead(message);
        UserResult secondResult = user.MarkAsRead(message);

        // assert
        Assert.IsType<UserResult.Success>(firstResult);
        Assert.IsType<UserResult.Failure>(secondResult);
    }
}