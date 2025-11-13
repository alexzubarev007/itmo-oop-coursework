using Itmo.ObjectOrientedProgramming.Lab3.Creatures.ConcreteCreatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures.Builders;

public sealed class AmuletMasterBuilder : CreatureBuilderBase
{
    public override ICreature Build()
    {
        ICreature creature = new AmuletMaster();
        creature = ApplyModifiers(creature);
        return creature;
    }

    protected override ICreature ApplyModifiers(ICreature creature)
    {
        creature = new MagicShieldApplier().Apply(creature);
        creature = new AttackingSkillApplier().Apply(creature);

        return base.ApplyModifiers(creature);
    }
}