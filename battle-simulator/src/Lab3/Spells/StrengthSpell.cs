using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class StrengthSpell : ISpell
{
    public ICreature Use(ICreature creature)
    {
        creature.ChangeAttack(creature.AttackIndicator.IncreaseBy(5).Value);
        return creature;
    }
}