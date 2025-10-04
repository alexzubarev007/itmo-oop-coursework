using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Sections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Routes;

public record Route
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
            SectionResult sectionResult = section.DriveSection(train);
            switch (sectionResult)
            {
                case SectionResult.Success success:
                    totalTime += success.Time;
                    break;
                default:
                    return new RouteResult.Failure(sectionResult);
            }
        }

        if (train.Speed > MaxFinalSpeed)
        {
            return new RouteResult.Failure(new SectionResult.SpeedLimitBroken(MaxFinalSpeed));
        }

        return new RouteResult.Success(totalTime);
    }
}