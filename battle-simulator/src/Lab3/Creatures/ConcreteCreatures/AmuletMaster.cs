namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

public sealed class AmuletMaster : CreatureBase
{
    public AmuletMaster() : base(5, 2) { }

    public override ICreature Copy()
        => new AmuletMaster(AttackIndicator.Value, HealthIndicator.Value);

    private AmuletMaster(int attack, int health) : base(attack, health) { }
}