using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Generators;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables;

public class Table
{
    private const int MaxCreaturesCount = 7;

    private readonly List<ICreature> _creatures = new();

    private readonly IRandom _randomGenerator;

    public Table(IRandom randomGenerator)
    {
        _randomGenerator = randomGenerator;
    }

    public AddCreatureResult Add(ICreature creature)
    {
        if (_creatures.Count >= MaxCreaturesCount)
        {
            return new AddCreatureResult.Failure();
        }

        _creatures.Add(creature);
        return new AddCreatureResult.Success();
    }

    public Table UseSpell(ISpell spell, ICreature creature)
    {
        int creatureIndex = _creatures.IndexOf(creature);

        if (creatureIndex == -1)
        {
            throw new ArgumentException("Creature not found");
        }

        _creatures[creatureIndex] = spell.Use(_creatures[creatureIndex]);
        return this;
    }

    public ICreature? FindAttacking(int previousQueueIndex)
    {
        if (_creatures.Count == 0)
        {
            return null;
        }

        int firstCreatureIndex = (previousQueueIndex + 1) % _creatures.Count;

        return FindAliveCreature(firstCreatureIndex);
    }

    public ICreature? FindAttacked()
    {
        if (_creatures.Count == 0)
        {
            return null;
        }

        int startCreatureIndex = _randomGenerator.Generate(0, _creatures.Count);

        return FindAliveCreature(startCreatureIndex);
    }

    public Table Copy()
    {
        Table tableCopy = new(_randomGenerator);

        foreach (ICreature creature in _creatures)
        {
            tableCopy.Add(creature.Copy());
        }

        return tableCopy;
    }

    public ICreature GetCreatureById(int index)
    {
        return _creatures[index];
    }

    private ICreature? FindAliveCreature(int startIndex)
    {
        int currentCreatureIndex = startIndex;
        int iterationsCount = 0;
        ICreature currentCreature = _creatures[currentCreatureIndex];

        while (!CheckAlive(currentCreature))
        {
            UpdateFindingCycleParameters(ref currentCreatureIndex, ref iterationsCount);
            currentCreature = _creatures[currentCreatureIndex];

            if (CheckCycleEndWithoutFinding(iterationsCount))
            {
                return null;
            }
        }

        return currentCreature;
    }

    private bool CheckAlive(ICreature creature)
    {
        return creature.HealthIndicator.IsPositive();
    }

    private void UpdateFindingCycleParameters(ref int currentCreatureIndex, ref int iterationsCount)
    {
        currentCreatureIndex = (currentCreatureIndex + 1) % _creatures.Count;
        ++iterationsCount;
    }

    private bool CheckCycleEndWithoutFinding(int iterationsCount)
    {
        return iterationsCount > _creatures.Count;
    }
}