using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public sealed record Station : ITrackSection
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
            return new SectionResult.SpeedLimitBroken(MaxSpeed);
        }

        return new SectionResult.Success(BoardingTime + DisembarkationTime);
    }
}