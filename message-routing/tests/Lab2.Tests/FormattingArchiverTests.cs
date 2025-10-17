using Itmo.ObjectOrientedProgramming.Lab2.Archivers;
using Itmo.ObjectOrientedProgramming.Lab2.Formatters;
using Itmo.ObjectOrientedProgramming.Lab2.Messages;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class FormattingArchiverTests
{
    [Fact]
    public void Formatter_WhenFormattingArchiversImplements_Writes()
    {
        // arrange
        var message = new Message("Random Header", "Random Text", ImportanceLevel.Medium);
        IFormatter formatter = Substitute.For<IFormatter>();
        var formattingArchiver = new FormattingArchiver(formatter);

        // act
        formattingArchiver.Store(message);

        // assert
        formatter.Received(1).WriteHeader(message);
        formatter.Received(1).WriteBody(message);
    }
}