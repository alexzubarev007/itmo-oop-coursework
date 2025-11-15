using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class BattleAnalystBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder() => new BattleAnalystBuilder()
        .WithAttack(new AttackParameter(2))
        .WithHealth(new HealthParameter(4));
}