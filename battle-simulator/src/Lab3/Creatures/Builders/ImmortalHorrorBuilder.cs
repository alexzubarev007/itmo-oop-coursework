using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public sealed class ImmortalHorrorBuilder : CreatureBuilderBase
{
    public override ICreature Build()
    {
        ICreature creature = new ImmortalHorror();
        creature = ApplyModifiers(creature);
        return creature;
    }
}