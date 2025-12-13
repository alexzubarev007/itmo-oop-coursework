using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.ConcreteCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders;

public sealed class DisconnectCommandBuilder : ICommandBuilder
{
    public CommandBuilderResult Build()
    {
        return new CommandBuilderResult.Success(new DisconnectCommand());
    }
}