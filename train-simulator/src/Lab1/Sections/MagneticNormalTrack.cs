using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public sealed record MagneticNormalTrack : ITrackSection
{
    public MagneticNormalTrack(Length length)
    {
        Length = length;
    }

    public Length Length { get; }

    public SectionResult DriveSection(Train train)
    {
        DistanceResult distanceResult = train.DriveUniformMotion(Length);

        return distanceResult switch
        {
            DistanceResult.Success success => new SectionResult.Success(success.TotalTime),
            _ => new SectionResult.MovementFailure(distanceResult),
        };
    }
}