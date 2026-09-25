using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class DefendingAmulet : ISpell
{
    public ICreature Use(ICreature creature)
    {
        return new MagicShield(creature);
    }
}