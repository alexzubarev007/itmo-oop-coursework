using Itmo.ObjectOrientedProgramming.Lab1.Errors;
using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

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

    public SectionResult PassSection(Train train)
    {
        if (train.Speed > MaxSpeed)
        {
            return new SectionResult.Failure(new SpeedLimitError(MaxSpeed));
        }

        return new SectionResult.Success(BoardingTime + DisembarkationTime);
    }
}