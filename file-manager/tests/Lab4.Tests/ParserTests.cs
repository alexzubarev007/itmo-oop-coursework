using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.ConcreteCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParserFactoryLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    [Fact]
    public void Parser_WhenCorrectConnectCommandWithNonDefaultFlag_ParsesSuccessfully()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "connect /SimpleDirectory/ConnectionPath -m local";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        ConnectCommand command = Assert.IsType<ConnectCommand>(result.Command);
        Assert.Equal("/SimpleDirectory/ConnectionPath", command.ConnectionPath);
        Assert.Equal("local", command.Mode);
    }

    [Fact]
    public void Parser_WhenCorrectConnectCommandWithDefaultFlag_ParsesSuccessfully()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "connect /SimpleDirectory/ConnectionPath";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        ConnectCommand command = Assert.IsType<ConnectCommand>(result.Command);
        Assert.Equal("/SimpleDirectory/ConnectionPath", command.ConnectionPath);
        Assert.Equal("local", command.Mode);
    }

    [Fact]
    public void Parser_WhenCorrectDisconnectCommand_ParsesSuccessfully()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "disconnect";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        Assert.IsType<DisconnectCommand>(result.Command);
    }

    [Fact]
    public void Parser_WhenCorrectGoToCommand_ParsesSuccessfully()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "tree goto /NewPath";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        GoToCommand command = Assert.IsType<GoToCommand>(result.Command);
        Assert.Equal("/NewPath", command.NewPath);
    }

    [Fact]
    public void Parser_WhenCorrectTreeListCommand_ParsesSuccessfully()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "tree list -d 5";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        TreeListCommand command = Assert.IsType<TreeListCommand>(result.Command);
        Assert.Equal(5, command.Depth);
    }

    [Fact]
    public void Parser_WhenTreeListCommandWithoutCorrectFlag_FailsParsing()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "tree list -d -2";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        Assert.IsType<ParsingResult.Failure>(parsed);
    }

    [Fact]
    public void Parser_WhenTreeListCommandWithoutFlag_FailsParsing()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "tree list ";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        Assert.IsType<ParsingResult.Failure>(parsed);
    }

    [Fact]
    public void Parser_WhenCorrectFileShowCommand_FailsParsing()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "file show ../filepath -m console";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        ShowFileCommand command = Assert.IsType<ShowFileCommand>(result.Command);
        Assert.Equal("../filepath", command.FilePath);
        Assert.Equal("console", command.WritingMode);
    }

    [Fact]
    public void Parser_WhenCorrectFileShowCommandWithIncorrectFlag_FailsParsing()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "file show ../filepath -k console";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        Assert.IsType<ParsingResult.Failure>(parsed);
    }

    [Fact]
    public void Parser_WhenCorrectFileMoveCommand_ParsesSuccessfully()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "file move sourcePath destinationPath";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        MoveFileCommand command = Assert.IsType<MoveFileCommand>(result.Command);
        Assert.Equal("sourcePath", command.SourcePath);
        Assert.Equal("destinationPath", command.DestinationPath);
    }

    [Fact]
    public void Parser_WhenCorrectFileCopyCommand_ParsesSuccessfully()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "file copy sourcePath destinationPath";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        CopyFileCommand command = Assert.IsType<CopyFileCommand>(result.Command);
        Assert.Equal("sourcePath", command.SourcePath);
        Assert.Equal("destinationPath", command.DestinationPath);
    }

    [Fact]
    public void Parser_WhenCorrectRenameFileCommand_ParsesSuccessfully()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "file rename sourcePath file.jpeg";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        RenameFileCommand command = Assert.IsType<RenameFileCommand>(result.Command);
        Assert.Equal("sourcePath", command.FilePath);
        Assert.Equal("file.jpeg", command.NewName);
    }

    [Fact]
    public void Parser_WhenRenameFileCommandWithNotEnoughPositionalArguments_FailsParsing()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "file rename sourcePath";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        Assert.IsType<ParsingResult.Failure>(parsed);
    }

    [Fact]
    public void Parser_WhenCorrectDeleteFileCommand_ParsesSuccessfully()
    {
        // arrange
        ICommandParserFactoryLink commandsChain = new DefaultCommandChainFactory().Create();
        var parser = new Parser(commandsChain);
        string commandLine = "file delete sourcePath";

        // act
        ParsingResult parsed = parser.Parse(commandLine);

        // assert
        ParsingResult.Success result = Assert.IsType<ParsingResult.Success>(parsed);
        DeleteFileCommand command = Assert.IsType<DeleteFileCommand>(result.Command);
        Assert.Equal("sourcePath", command.FilePath);
    }
}