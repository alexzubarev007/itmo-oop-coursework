using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public sealed class AmuletMasterBuilder : CreatureBuilderBase
{
    protected override ICreature Create()
    {
        if (AttackIndicator is null || HealthIndicator is null)
        {
            throw new ArgumentException("Amulet master can't be built");
        }

        return new AmuletMaster(AttackIndicator, HealthIndicator);
    }
}