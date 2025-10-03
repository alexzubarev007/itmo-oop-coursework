using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public sealed record MagneticForceTrack : ITrackSection
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
        if (!train.IsForceInLimit(Force))
        {
            return new SectionResult.ForceLimitBroken(Force);
        }

        DistanceResult distanceResult = train.DriveUniformlyAccelerated(Length, Force);

        return distanceResult switch
            {
                DistanceResult.Success success => new SectionResult.Success(success.TotalTime),
                _ => new SectionResult.MovementFailure(distanceResult),
            };
    }
}