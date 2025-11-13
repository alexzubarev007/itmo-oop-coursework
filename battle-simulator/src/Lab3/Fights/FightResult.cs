namespace Itmo.ObjectOrientedProgramming.Lab3.Fights;

public abstract record FightResult
{
    private FightResult() { }

    public sealed record FirstPlayerWin : FightResult;

    public sealed record SecondPlayerWin : FightResult;

    public sealed record Draw : FightResult;
}