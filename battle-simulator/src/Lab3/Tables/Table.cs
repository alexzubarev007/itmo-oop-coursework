using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Results;
using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class Table
{
    private const int MaxCreaturesCount = 7;

    private readonly List<ICreature> _creatures = new();

    public TableResult Add(ICreature creature)
    {
        if (_creatures.Count >= MaxCreaturesCount)
        {
            return new TableResult.Failure(new AddCreatureError());
        }

        _creatures.Add(creature.Copy());
        return new TableResult.Success();
    }

    public Table UseSpell(ISpell spell, int creatureIndex)
    {
        _creatures[creatureIndex] = spell.Use(_creatures[creatureIndex]);
        return this;
    }

    public ICreature? FindAttacking(int previousQueueIndex)
    {
        if (_creatures.Count == 0)
        {
            return null;
        }

        int currentAttackingIndex = (previousQueueIndex + 1) % _creatures.Count;
        int iterationsCount = 0;

        while (!(_creatures[currentAttackingIndex].AttackIndicator.IsPositive()
                 && _creatures[currentAttackingIndex].HealthIndicator.IsPositive()))
        {
            currentAttackingIndex = (currentAttackingIndex + 1) % _creatures.Count;
            ++iterationsCount;

            if (iterationsCount > _creatures.Count)
            {
                return null;
            }
        }

        return _creatures[currentAttackingIndex];
    }

    public ICreature? FindAttacked()
    {
        if (_creatures.Count == 0)
        {
            return null;
        }

        int attackedIndex = RandomNumberGenerator.GetInt32(0, _creatures.Count);
        int iterationsCount = 0;

        while (!_creatures[attackedIndex].HealthIndicator.IsPositive())
        {
            attackedIndex = (attackedIndex + 1) % _creatures.Count;
            ++iterationsCount;

            if (iterationsCount > _creatures.Count)
            {
                return null;
            }
        }

        return _creatures[attackedIndex];
    }

    public Table Copy()
    {
        Table tableCopy = new();

        foreach (ICreature creature in _creatures)
        {
            tableCopy.Add(creature);
        }

        return tableCopy;
    }

    public ICreature GetCreatureById(int index)
    {
        return _creatures[index];
    }
}