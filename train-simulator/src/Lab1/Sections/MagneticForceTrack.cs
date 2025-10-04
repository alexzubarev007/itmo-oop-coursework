using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Sections.Errors;

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

    public SectionResult DriveSection(Train train)
    {
        if (!train.TryRecalculateAcceleration(Force))
        {
            return new SectionResult.Failure(new ForceLimitError(train.MaxForce));
        }

        DistanceResult distanceResult = train.DriveDistance(Length);

        return distanceResult switch
        {
            DistanceResult.Success success => new SectionResult.Success(success.TotalTime),
            _ => new SectionResult.Failure(new DistanceError()),
        };
    }
}