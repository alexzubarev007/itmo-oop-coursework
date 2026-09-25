using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Fights;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Generators;

namespace BattleDemo;

public static class Program
{
    public static void Main()
    {
        ICreature analyst = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .Build();
        ICreature mimic = new MimicChestBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        var firstTable = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());
        firstTable.Add(analyst);
        secondTable.Add(mimic);

        FightResult result = new Fight(firstTable, secondTable).Play();

        Console.WriteLine($"First player won: {result is FightResult.FirstPlayerWin}");
        Console.WriteLine($"Analyst on the table: {analyst.AttackIndicator.Value}/{analyst.HealthIndicator.Value}");
        Console.WriteLine($"Mimic on the table: {mimic.AttackIndicator.Value}/{mimic.HealthIndicator.Value}");
    }
}
