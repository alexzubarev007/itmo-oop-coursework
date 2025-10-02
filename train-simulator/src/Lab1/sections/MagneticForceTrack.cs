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

    public Length Length { get;  }

    public Force Force { get;  }

    public SectionResult DriveSection(Train train)
    {
        if (Force.GetAbs() > train.MaxForce)
        {
            return new SectionResult.ForceLimitBroken(Force);
        }

        return train.DriveDistance(Length, Force);
    }
}