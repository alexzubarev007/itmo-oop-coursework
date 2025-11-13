using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public sealed class EvilFighterBuilder : CreatureBuilderBase
{
    public override ICreature Build()
    {
        ICreature creature = new EvilFighter();
        creature = ApplyModifiers(creature);
        return creature;
    }
}