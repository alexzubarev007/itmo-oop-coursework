using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers;

public sealed class MoveFileCommandParser : ICommandParser
{
    private readonly IReadOnlyList<IPositionalApplier<MoveFileCommandBuilder>> _positionalAppliers;

    private readonly IFlagApplierLink<MoveFileCommandBuilder>? _flagApplierChain;

    public MoveFileCommandParser(
        IReadOnlyList<IPositionalApplier<MoveFileCommandBuilder>> positionalAppliers,
        IFlagApplierLink<MoveFileCommandBuilder>? applierChain)
    {
        _positionalAppliers = positionalAppliers;

        _flagApplierChain = applierChain;
    }

    public ParsingResult Parse(string[] tokens)
    {
        var builder = new MoveFileCommandBuilder();

        int currentIndex = 2;

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

    private IParsingError? ParsePositional(MoveFileCommandBuilder builder, string[] tokens, ref int currentIndex)
    {
        foreach (IPositionalApplier<MoveFileCommandBuilder> positionalArgument
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

    private IParsingError? ParseFlag(
        MoveFileCommandBuilder builder,
        string[] tokens,
        ref int currentIndex)
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