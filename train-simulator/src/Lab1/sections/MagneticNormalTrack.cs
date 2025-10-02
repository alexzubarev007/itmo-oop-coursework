using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

using Itmo.ObjectOrientedProgramming.Lab1.Results;

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
        return train.DriveDistance(Length);
    }
}