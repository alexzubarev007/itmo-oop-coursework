using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class BattleAnalystBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder() => new BattleAnalystBuilder();
}