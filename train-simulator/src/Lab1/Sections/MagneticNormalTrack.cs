using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public sealed class MagneticNormalTrack : ITrackSection
{
    public MagneticNormalTrack(Length length)
    {
        Length = length;
    }

    public Length Length { get; }

    public SectionResult PassSection(Train train)
    {
        TrainResult trainResult = train.PassDistance(Length);

        return trainResult switch
        {
            TrainResult.Success success => new SectionResult.Success(success.TotalTime),
            _ => new SectionResult.Failure(new MovementError()),
        };
    }
}