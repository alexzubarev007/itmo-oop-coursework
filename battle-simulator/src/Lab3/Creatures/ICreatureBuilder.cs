using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreatureBuilder
{
    ICreatureBuilder WithModifier(IModifierApplier modifier);

    ICreatureBuilder WithAttack(AttackParameter attack);

    ICreatureBuilder WithHealth(HealthParameter health);

    ICreature Build();
}