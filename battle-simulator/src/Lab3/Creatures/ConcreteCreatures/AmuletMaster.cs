using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class AmuletMaster : CreatureBase
{
    public AmuletMaster(AttackParameter attack, HealthParameter health) : base(attack, health) { }

    public override ICreature Copy()
        => new AmuletMaster(AttackIndicator, HealthIndicator);
}