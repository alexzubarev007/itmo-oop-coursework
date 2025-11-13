using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public sealed class BattleAnalystBuilder : CreatureBuilderBase
{
    public override ICreature Build()
    {
        ICreature creature = new BattleAnalyst();
        creature = ApplyModifiers(creature);
        return creature;
    }
}