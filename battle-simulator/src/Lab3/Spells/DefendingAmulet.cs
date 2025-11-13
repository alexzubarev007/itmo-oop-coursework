using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class DefendingAmulet : ISpell
{
    public ICreature Use(ICreature creature)
    {
        return new MagicShieldApplier().Apply(creature);
    }
}