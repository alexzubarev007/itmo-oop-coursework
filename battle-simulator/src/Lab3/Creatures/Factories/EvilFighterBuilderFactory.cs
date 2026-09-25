using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class EvilFighterBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder() => new EvilFighterBuilder()
        .WithAttack(new AttackParameter(1))
        .WithHealth(new HealthParameter(6));
}