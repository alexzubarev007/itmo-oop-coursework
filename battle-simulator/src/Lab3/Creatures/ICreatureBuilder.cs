using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreatureBuilder
{
    ICreatureBuilder WithModifier(IModifierApplier modifier);

    ICreature Build();
}