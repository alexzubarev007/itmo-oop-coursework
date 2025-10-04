using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Sections.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public sealed class MagneticNormalTrack : ITrackSection
{
    public MagneticNormalTrack(Length length)
    {
        Length = length;
    }

    public Length Length { get; }

    public SectionResult DriveSection(Train train)
    {
        train.SetAccelerationZero();

        DistanceResult distanceResult = train.DriveDistance(Length);

        return distanceResult switch
        {
            DistanceResult.Success success => new SectionResult.Success(success.TotalTime),
            _ => new SectionResult.Failure(new DistanceError()),
        };
    }
}