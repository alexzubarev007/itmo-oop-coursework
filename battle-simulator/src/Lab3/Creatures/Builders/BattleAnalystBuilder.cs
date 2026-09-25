using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public sealed class BattleAnalystBuilder : CreatureBuilderBase
{
    protected override ICreature Create()
    {
        if (AttackIndicator is null || HealthIndicator is null)
        {
            throw new ArgumentException("Battle analyst can't be built");
        }

        return new BattleAnalyst(AttackIndicator, HealthIndicator);
    }
}