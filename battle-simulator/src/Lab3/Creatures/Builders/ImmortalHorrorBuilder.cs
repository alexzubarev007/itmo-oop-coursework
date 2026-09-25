using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public sealed class ImmortalHorrorBuilder : CreatureBuilderBase
{
    protected override ICreature Create()
    {
        if (AttackIndicator is null || HealthIndicator is null)
        {
            throw new ArgumentException("Immortal Horror can't be built");
        }

        return new ImmortalHorror(AttackIndicator, HealthIndicator);
    }
}