using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;

public class MagicShieldApplier : IModifierApplier
{
    public ICreature Apply(ICreature creature)
    {
        return new MagicShield(creature);
    }
}