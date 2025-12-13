using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands.Builders.BuildingResults;

namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;

public interface ICommandBuilder
{
    CommandBuilderResult Build();
}
