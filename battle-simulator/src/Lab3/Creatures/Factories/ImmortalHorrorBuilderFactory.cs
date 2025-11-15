using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;

public sealed class ImmortalHorrorBuilderFactory : ICreatureBuilderFactory
{
    public ICreatureBuilder CreateBuilder() => new ImmortalHorrorBuilder()
        .WithAttack(new AttackParameter(4))
        .WithHealth(new HealthParameter(4));
}