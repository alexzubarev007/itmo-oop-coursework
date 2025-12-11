using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers;

public sealed class DisconnectCommandParser : ICommandParser
{
    private readonly IReadOnlyList<IPositionalApplier<DisconnectCommandBuilder>> _positionalAppliers;

    private readonly IFlagApplierLink<DisconnectCommandBuilder>? _flagApplierChain;

    public DisconnectCommandParser(
        IReadOnlyList<IPositionalApplier<DisconnectCommandBuilder>> positionalAppliers,
        IFlagApplierLink<DisconnectCommandBuilder>? applierChain)
    {
        _positionalAppliers = positionalAppliers;

        _flagApplierChain = applierChain;
    }

    public ParsingResult Parse(string[] tokens)
    {
        var builder = new DisconnectCommandBuilder();

        int currentIndex = 1;

        IParsingError? positionalError = ParsePositional(builder, tokens, ref currentIndex);

        if (positionalError is not null)
        {
            return new ParsingResult.Failure(positionalError);
        }

        IParsingError? flagError = ParseFlag(builder, tokens, ref currentIndex);

        if (flagError is not null)
        {
            return new ParsingResult.Failure(flagError);
        }

        if (!builder.IsEveryFieldInitialized())
        {
            return new ParsingResult.Failure(new UninitializingError());
        }

        ICommand command = builder.Build();

        return new ParsingResult.Success(command);
    }

    private IParsingError? ParsePositional(DisconnectCommandBuilder builder, string[] tokens, ref int currentIndex)
    {
        foreach (IPositionalApplier<DisconnectCommandBuilder> positionalArgument
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

    private IParsingError? ParseFlag(DisconnectCommandBuilder builder, string[] tokens, ref int currentIndex)
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