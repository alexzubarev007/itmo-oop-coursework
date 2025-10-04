using Itmo.ObjectOrientedProgramming.Lab1.Parameters;

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

    public DistanceResult DriveDistance(Length distance)
    {
        Length remainingDistance = distance.Duplicate();
        var totalTime = new Time(0);

        while (remainingDistance.IsPositive())
        {
            Speed += Speed.Create(_acceleration, _deltaTime);

            if (Speed.IsNegativeOrZero() && _acceleration.IsNegativeOrZero())
            {
                return new DistanceResult.PrematureStop();
            }

            Length step = remainingDistance.Create(Speed, _deltaTime);
            totalTime += _deltaTime;

            if (remainingDistance < step)
            {
                break;
            }

            remainingDistance -= step;
        }

        return new DistanceResult.Success(totalTime);
    }

    public bool TryRecalculateAcceleration(Force externalForce)
    {
        if (!IsForceInLimit(externalForce))
        {
            return false;
        }

        _acceleration = _acceleration.Create(externalForce, _mass);
        return true;
    }

    public void SetAccelerationZero()
    {
        _acceleration = new Acceleration(0);
    }

    private bool IsForceInLimit(Force force)
    {
        return !(force.GetAbs() > MaxForce);
    }
}