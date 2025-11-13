using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public interface ICreature
{
    AttackParameter AttackIndicator { get; }

    HealthParameter HealthIndicator { get; }

    void Attack(ICreature other);

    void ReceiveDamage(AttackParameter damaging);

    void ChangeAttack(int value);

    void ChangeHealth(int value);

    ICreature Copy();
}