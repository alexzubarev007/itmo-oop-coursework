using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public sealed class MimicChestBuilder : CreatureBuilderBase
{
    protected override ICreature Create()
    {
        if (AttackIndicator is null || HealthIndicator is null)
        {
            throw new ArgumentException("Mimic chest can't be built");
        }

        return new MimicChest(AttackIndicator, HealthIndicator);
    }
}