using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;

public class AttackingSkillApplier : IModifierApplier
{
    public ICreature Apply(ICreature creature)
    {
        return new AttackingSkill(creature);
    }
}