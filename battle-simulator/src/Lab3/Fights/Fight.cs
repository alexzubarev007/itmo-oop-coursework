using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;

namespace Itmo.ObjectOrientedProgramming.Lab3.Fights;

public class Fight
{
    private readonly Table _firstTable;
    private readonly Table _secondTable;

    public Fight(Table firstTable, Table secondTable)
    {
        _firstTable = firstTable.Copy();
        _secondTable = secondTable.Copy();
    }

    public FightResult Play()
    {
        Table attackingTable = _firstTable;
        Table attackedTable = _secondTable;

        bool isFirstPlayerAttacking = true;
        int previousStepIndex = -1;

        FightResult? result = null;
        ICreature? attackingCreature;
        ICreature? attackedCreature;

        while (result is null)
        {
            attackingCreature = attackingTable.FindAttacking(previousStepIndex);
            attackedCreature = attackedTable.FindAttacked();

            if (attackingCreature is not null && attackedCreature is not null)
            {
                attackingCreature.Attack(attackedCreature);
            }

            result = CheckStepResulting(attackingCreature, attackedCreature, isFirstPlayerAttacking);

            if (!isFirstPlayerAttacking)
            {
                ++previousStepIndex;
            }

            (attackingTable, attackedTable) = (attackedTable, attackingTable);
            isFirstPlayerAttacking = !isFirstPlayerAttacking;
        }

        return result;
    }

    private static FightResult? CheckStepResulting(
        ICreature? attackingCreature,
        ICreature? attackedCreature,
        bool isFirstAttack)
    {
        if (attackingCreature is null && attackedCreature is null)
        {
            return new FightResult.Draw();
        }

        if (attackingCreature is not null && attackedCreature is null)
        {
            return isFirstAttack ? new FightResult.FirstPlayerWin() : new FightResult.SecondPlayerWin();
        }

        return null;
    }
}