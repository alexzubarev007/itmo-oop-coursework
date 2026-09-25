using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Sections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public class Route
{
    private readonly List<ITrackSection> _sections;

    public Route(Speed maxFinalSpeed, IEnumerable<ITrackSection> sections)
    {
        MaxFinalSpeed = maxFinalSpeed;
        _sections = sections.ToList();
    }

    public Speed MaxFinalSpeed { get; }

    public RouteResult DriveTrain(Train train)
    {
        var totalTime = new Time(0);

        foreach (ITrackSection section in _sections)
        {
            if (section is MagneticNormalTrack)
            {
                train.RecalculateWithoutForce();
            }

            SectionResult sectionResult = section.PassSection(train);

            if (sectionResult is SectionResult.Success success)
            {
                totalTime += success.Time;
            }

            if (sectionResult is SectionResult.Failure failure)
            {
                return new RouteResult.Failure(failure.Error);
            }
        }

        if (train.Speed > MaxFinalSpeed)
        {
            return new RouteResult.Failure(new SpeedLimitError(MaxFinalSpeed));
        }

        return new RouteResult.Success(totalTime);
    }
}