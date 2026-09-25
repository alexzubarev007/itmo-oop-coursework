using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.Results.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parsers.CommandParsers;

public class CommandParser<TCommandBuilder> : ICommandParser
    where TCommandBuilder : ICommandBuilder
{
    private readonly IPositionalApplierLink<TCommandBuilder>? _positionalChain;
    private readonly IFlagApplierLink<TCommandBuilder>? _flagChain;
    private readonly TCommandBuilder _builder;

    public CommandParser(
        TCommandBuilder builder,
        IPositionalApplierLink<TCommandBuilder>? positionalChain,
        IFlagApplierLink<TCommandBuilder>? flagChain)
    {
        _builder = builder;
        _positionalChain = positionalChain;
        _flagChain = flagChain;
    }

    public ParsingResult Parse(IEnumerator<string> current)
    {
        if (_positionalChain is not null)
        {
            bool positionalParsed = _positionalChain.TryApply(_builder, current);
            if (!positionalParsed)
            {
                return new ParsingResult.Failure(new IncorrectValueError());
            }
        }

        if (_flagChain is not null)
        {
            while (current.MoveNext())
            {
                bool flagParsed = _flagChain.TryApply(_builder, current);
                if (!flagParsed)
                {
                    return new ParsingResult.Failure(new IncorrectValueError());
                }
            }
        }

        CommandBuilderResult builderResult = _builder.Build();
        if (builderResult is CommandBuilderResult.Success success)
        {
            return new ParsingResult.Success(success.Command);
        }

        return new ParsingResult.Failure(new UninitializingError());
    }
}