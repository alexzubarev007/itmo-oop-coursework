using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public sealed class EvilFighterBuilder : CreatureBuilderBase
{
    protected override ICreature Create()
    {
        if (AttackIndicator is null || HealthIndicator is null)
        {
            throw new ArgumentException("Evil Fighter can't be built");
        }

        return new EvilFighter(AttackIndicator, HealthIndicator);
    }
}