using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public abstract record SectionResult
{
    private SectionResult() { }

    public sealed record Success(Time Time) : SectionResult { }

    public sealed record ForceLimitBroken(Force ForceLimit) : SectionResult { }

    public sealed record SpeedLimitBroken(Speed SpeedLimit) : SectionResult { }

    public sealed record MovementFailure(DistanceResult DistanceFailure) : SectionResult { }
}