using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public sealed class MagneticForceTrack : ITrackSection
{
    public MagneticForceTrack(Length length, Force force)
    {
        Length = length;
        Force = force;
    }

    public Length Length { get; }

    public Force Force { get; }

    public SectionResult PassSection(Train train)
    {
        if (!train.TryRecalculateAcceleration(Force))
        {
            return new SectionResult.Failure(new ForceLimitError(train.MaxForce));
        }

        TrainResult distanceResult = train.PassDistance(Length);

        return distanceResult switch
        {
            TrainResult.Success success => new SectionResult.Success(success.TotalTime),
            _ => new SectionResult.Failure(new MovementError()),
        };
    }
}