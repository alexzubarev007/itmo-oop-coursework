using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Sections.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public sealed class Station : ITrackSection
{
    public Station(Speed maxSpeed, Time boardingTime, Time disembarkationTime)
    {
        MaxSpeed = maxSpeed;
        BoardingTime = boardingTime;
        DisembarkationTime = disembarkationTime;
    }

    public Speed MaxSpeed { get; }

    public Time BoardingTime { get; }

    public Time DisembarkationTime { get; }

    public SectionResult DriveSection(Train train)
    {
        if (train.Speed > MaxSpeed)
        {
            return new SectionResult.Failure(new SpeedLimitError(MaxSpeed));
        }

        return new SectionResult.Success(BoardingTime + DisembarkationTime);
    }
}