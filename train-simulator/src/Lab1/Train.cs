using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Train
{
    private readonly Time _deltaTime;

    private readonly Mass _mass;

    private Acceleration _acceleration;

    public Train(Mass mass, Force maxForce, Time deltaTime)
    {
        _acceleration = new Acceleration(0);
        Speed = new Speed(0);
        MaxForce = maxForce;
        _mass = mass;
        _deltaTime = deltaTime;
    }

    public Force MaxForce { get; }

    public Speed Speed { get; private set; }

    public SectionResult DriveDistance(Length distance)
    {
        return DriveDistance(distance, new Force(0));
    }

    public SectionResult DriveDistance(Length distance, Force force)
    {
        _acceleration = _acceleration.Create(force, _mass);

        Length remainingDistance = distance with { };
        var totalTime = new Time(0);

        while (remainingDistance.IsPositive())
        {
            Speed += Speed.Create(_acceleration, _deltaTime);

            if (Speed.IsNegativeOrZero() && _acceleration.IsNegativeOrZero())
            {
                return new SectionResult.PrematureStop();
            }

            Length step = remainingDistance.Create(Speed, _deltaTime);
            totalTime += _deltaTime;

            if (remainingDistance < step)
            {
                break;
            }

            remainingDistance -= step;
        }

        return new SectionResult.Success(totalTime);
    }
}