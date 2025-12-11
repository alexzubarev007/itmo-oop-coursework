using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers;

public sealed class ConnectCommandParser : ICommandParser
{
    private readonly IReadOnlyList<IPositionalApplier<ConnectCommandBuilder>> _positionalAppliers;

    private readonly IFlagApplierLink<ConnectCommandBuilder>? _flagApplierChain;

    public ConnectCommandParser(
        IReadOnlyList<IPositionalApplier<ConnectCommandBuilder>> positionalAppliers,
        IFlagApplierLink<ConnectCommandBuilder>? applierChain)
    {
        _positionalAppliers = positionalAppliers;

        _flagApplierChain = applierChain;
    }

    public ParsingResult Parse(string[] tokens)
    {
        var connectCommandBuilder = new ConnectCommandBuilder();

        int currentIndex = 1;

        IParsingError? positionalError = ParsePositional(connectCommandBuilder, tokens, ref currentIndex);

        if (positionalError is not null)
        {
            return new ParsingResult.Failure(positionalError);
        }

        IParsingError? flagError = ParseFlag(connectCommandBuilder, tokens, ref currentIndex);

        if (flagError is not null)
        {
            return new ParsingResult.Failure(flagError);
        }

        if (!connectCommandBuilder.IsEveryFieldInitialized())
        {
            return new ParsingResult.Failure(new UninitializingError());
        }

        ICommand command = connectCommandBuilder.Build();

        return new ParsingResult.Success(command);
    }

    private IParsingError? ParsePositional(ConnectCommandBuilder builder, string[] tokens, ref int currentIndex)
    {
        foreach (IPositionalApplier<ConnectCommandBuilder> positionalArgument
                 in _positionalAppliers)
        {
            if (currentIndex >= tokens.Length)
            {
                return new UninitializingError();
            }

            bool isPositionalParsed = positionalArgument
                .TryApply(builder, tokens[currentIndex]);

            if (!isPositionalParsed)
            {
                return new IncorrectValueError();
            }

            ++currentIndex;
        }

        return null;
    }

    private IParsingError? ParseFlag(ConnectCommandBuilder builder, string[] tokens, ref int currentIndex)
    {
        if (_flagApplierChain is not null)
        {
            while (currentIndex < tokens.Length)
            {
                if (currentIndex == tokens.Length - 1)
                {
                    return new UninitializingError();
                }

                bool isFlagParsed = _flagApplierChain
                                    .TryApply(builder, tokens[currentIndex], tokens[currentIndex + 1]);

                if (!isFlagParsed)
                {
                    return new IncorrectValueError();
                }

                currentIndex += 2;
            }
        }

        return null;
    }
}