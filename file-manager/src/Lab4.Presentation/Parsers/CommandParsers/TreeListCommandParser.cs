using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Commands.Builders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers;

public sealed class TreeListCommandParser : ICommandParser
{
    private readonly IReadOnlyList<IPositionalApplier<TreeListCommandBuilder>> _positionalAppliers;

    private readonly IFlagApplierLink<TreeListCommandBuilder>? _flagApplierChain;

    public TreeListCommandParser(
        IReadOnlyList<IPositionalApplier<TreeListCommandBuilder>> positionalAppliers,
        IFlagApplierLink<TreeListCommandBuilder>? applierChain)
    {
        _positionalAppliers = positionalAppliers;

        _flagApplierChain = applierChain;
    }

    public ParsingResult Parse(string[] tokens)
    {
        var builder = new TreeListCommandBuilder();

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

    private IParsingError? ParsePositional(
        TreeListCommandBuilder builder,
        string[] tokens,
        ref int currentIndex)
    {
        foreach (IPositionalApplier<TreeListCommandBuilder> positionalArgument
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

    private IParsingError? ParseFlag(TreeListCommandBuilder builder, string[] tokens, ref int currentIndex)
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