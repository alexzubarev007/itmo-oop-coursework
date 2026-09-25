using Itmo.ObjectOrientedProgramming.Lab3.Creatures;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Factories;
using Itmo.ObjectOrientedProgramming.Lab3.Creatures.Parameters;
using Itmo.ObjectOrientedProgramming.Lab3.Fights;
using Itmo.ObjectOrientedProgramming.Lab3.Modifiers.ModifierAppliers;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.Tables;
using Itmo.ObjectOrientedProgramming.Lab3.Tables.Generators;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class FightTests
{
    [Fact]
    public void BattleAnalystWithoutModifiers_WhenHeIsFirst_BeatsMimicChestWithoutModifiers()
    {
        // arrange
        ICreature battleAnalyst = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();
        var firstTable = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());
        firstTable.Add(battleAnalyst);
        secondTable.Add(mimicChest);

        // act
        FightResult result = new Fight(firstTable, secondTable).Play();

        // assert
        Assert.IsType<FightResult.FirstPlayerWin>(result);
    }

    [Fact]
    public void BattleAnalystWithoutModifiers_WhenHeIsFirst_BeatenByMimicChestWithMagicShield()
    {
        // arrange
        ICreature battleAnalyst = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest = new MimicChestBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        var firstTable = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());
        firstTable.Add(battleAnalyst);
        secondTable.Add(mimicChest);

        // act
        FightResult result = new Fight(firstTable, secondTable).Play();

        // assert
        Assert.IsType<FightResult.SecondPlayerWin>(result);
    }

    [Fact]
    public void BattleAnalystWithAttackingSkill_WhenHeIsFirst_BeatsMimicChestWithMagicShield()
    {
        // arrange
        ICreature battleAnalyst = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .Build();
        ICreature mimicChest = new MimicChestBuilderFactory()
            .CreateBuilder()
            .WithModifier(new MagicShieldApplier())
            .Build();
        var firstTable = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());
        firstTable.Add(battleAnalyst);
        secondTable.Add(mimicChest);

        // act
        FightResult result = new Fight(firstTable, secondTable).Play();

        // assert
        Assert.IsType<FightResult.FirstPlayerWin>(result);
    }

    [Fact]
    public void AttackingSkill_WhenItUsedTwice_MakeCreatureAttackFourTimes()
    {
        // arrange
        ICreature firstImmortalHorror = new ImmortalHorrorBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .Build();
        ICreature secondImmortalHorror = new ImmortalHorrorBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .WithModifier(new AttackingSkillApplier())
            .Build();
        ICreature amuletMaster = new AmuletMasterBuilderFactory()
            .CreateBuilder()
            .WithHealth(new HealthParameter(5))
            .Build();
        var firstTable1 = new Table(new CryptoRandom());
        var firstTable2 = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());
        firstTable1.Add(firstImmortalHorror);
        firstTable2.Add(secondImmortalHorror);

        // act
        secondTable.Add(amuletMaster);

        FightResult result1 = new Fight(firstTable1, secondTable).Play();
        FightResult result2 = new Fight(firstTable2, secondTable).Play();

        // assert
        Assert.IsType<FightResult.SecondPlayerWin>(result1);
        Assert.IsType<FightResult.FirstPlayerWin>(result2);
    }

    [Fact]
    public void AmuletMaster_WithThreeEnduranceSpells_BeatsThreeCreatures()
    {
        // arrange
        ICreature amuletMaster = new AmuletMasterBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature battleAnalyst = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature evilFighter = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature immortalHorror = new ImmortalHorrorBuilderFactory()
            .CreateBuilder()
            .Build();

        var firstTable = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());
        firstTable.Add(battleAnalyst);
        firstTable.Add(evilFighter);
        firstTable.Add(immortalHorror);

        secondTable.Add(amuletMaster);

        // act
        secondTable.UseSpell(new EnduranceSpell(), amuletMaster)
            .UseSpell(new EnduranceSpell(), amuletMaster)
            .UseSpell(new EnduranceSpell(), amuletMaster);
        FightResult result = new Fight(firstTable, secondTable).Play();

        // assert
        Assert.IsType<FightResult.SecondPlayerWin>(result);
    }

    [Fact]
    public void EmptyTables_WhenTheyFight_HaveDraw()
    {
        // arrange
        var firstTable = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());

        // act
        FightResult result = new Fight(firstTable, secondTable).Play();

        // asset
        Assert.IsType<FightResult.Draw>(result);
    }

    [Fact]
    public void ImmortalHorror_WhenDiesForFirstTime_Resurrects()
    {
        // arrange
        ICreature immortalHorror = new ImmortalHorrorBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature firstFightBattleAnalyst = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature secondFightBattleAnalyst = new BattleAnalystBuilderFactory()
            .CreateBuilder()
            .WithModifier(new AttackingSkillApplier())
            .Build();
        var firstBattleAnalystTable = new Table(new CryptoRandom());
        var secondBattleAnalystTable = new Table(new CryptoRandom());

        var immortalHorrorTable = new Table(new CryptoRandom());
        firstBattleAnalystTable.Add(firstFightBattleAnalyst);
        secondBattleAnalystTable.Add(secondFightBattleAnalyst);
        immortalHorrorTable.Add(immortalHorror);

        // act
        FightResult firstResult = new Fight(firstBattleAnalystTable, immortalHorrorTable).Play();
        FightResult secondResult = new Fight(secondBattleAnalystTable, immortalHorrorTable).Play();

        // assert
        Assert.IsType<FightResult.SecondPlayerWin>(firstResult);
        Assert.IsType<FightResult.FirstPlayerWin>(secondResult);
    }

    [Fact]
    public void InEpicFight_WhereFiveMimicChestFromEachSide_FirstWin()
    {
        ICreature mimicChest11 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest12 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest13 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest14 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest15 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();

        ICreature mimicChest21 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest22 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest23 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest24 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();
        ICreature mimicChest25 = new MimicChestBuilderFactory()
            .CreateBuilder()
            .Build();

        var firstTable = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());
        firstTable.Add(mimicChest11);
        firstTable.Add(mimicChest12);
        firstTable.Add(mimicChest13);
        firstTable.Add(mimicChest14);
        firstTable.Add(mimicChest15);

        secondTable.Add(mimicChest21);
        secondTable.Add(mimicChest22);
        secondTable.Add(mimicChest23);
        secondTable.Add(mimicChest24);
        secondTable.Add(mimicChest25);

        // act
        FightResult result = new Fight(firstTable, secondTable).Play();

        // assert
        Assert.IsType<FightResult.FirstPlayerWin>(result);
    }

    [Fact]
    public void ChangingCreatureParameters_WhenItHappensInFight_DoNotInfluenceOnCatalogCreature()
    {
        // arrange
        ICreature catalogAmuletMaster = new AmuletMasterBuilderFactory()
            .CreateBuilder()
            .Build();

        ICreature catalogEvilFighter = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .Build();

        var firstTable = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());
        firstTable.Add(catalogAmuletMaster);
        secondTable.Add(catalogEvilFighter);

        // act
        FightResult result = new Fight(firstTable, secondTable).Play();

        // assert
        Assert.IsType<FightResult.FirstPlayerWin>(result);
        Assert.Equal(6, catalogEvilFighter.HealthIndicator.Value);
    }

    [Fact]
    public void ChangingCreatureParameters_WhenItHappensInFight_DoNotInfluenceOnTableCreature()
    {
        // arrange
        ICreature catalogAmuletMaster = new AmuletMasterBuilderFactory()
            .CreateBuilder()
            .Build();

        ICreature catalogEvilFighter = new EvilFighterBuilderFactory()
            .CreateBuilder()
            .Build();

        var firstTable = new Table(new CryptoRandom());
        var secondTable = new Table(new CryptoRandom());
        firstTable.Add(catalogAmuletMaster);
        secondTable.Add(catalogEvilFighter);

        // act
        FightResult result = new Fight(firstTable, secondTable).Play();

        // assert
        Assert.IsType<FightResult.FirstPlayerWin>(result);
        Assert.Equal(6, secondTable.GetCreatureById(0).HealthIndicator.Value);
    }
}