using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Sections;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteTests
{
    [Fact]
    public void DriveTrain_SpeedInRouteLimit_ImplementsSuccessfully()
    {
        // arrange
        var train = new Train(new Mass(100000), new Force(600000), new Time(0.1));
        var route = new Route(
            new Speed(200),
            new List<ITrackSection>
            {
                new MagneticForceTrack(new Length(4010), new Force(500000)),
                new MagneticNormalTrack(new Length(500)),
            });

        // act
        RouteResult result = route.DriveTrain(train);

        // assert
        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void DriveTrain_SpeedMoreThanRouteLimit_Fails()
    {
        // arrange
        var train = new Train(new Mass(100000), new Force(600000), new Time(0.1));
        var route = new Route(
            new Speed(200),
            new List<ITrackSection>
            {
                new MagneticForceTrack(new Length(4020), new Force(500000)),
                new MagneticNormalTrack(new Length(500)),
            });

        // act
        RouteResult result = route.DriveTrain(train);

        // assert
        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void DriveTrain_SpeedInStationLimit_ImplementsSuccessfully()
    {
        // arrange
        var train = new Train(new Mass(100000), new Force(600000), new Time(0.1));
        var route = new Route(
            new Speed(200),
            new List<ITrackSection>
            {
                new MagneticForceTrack(new Length(4010), new Force(500000)),
                new MagneticNormalTrack(new Length(500)),
                new Station(new Speed(200), new Time(120), new Time(120)),
                new MagneticNormalTrack(new Length(500)),
            });

        // act
        RouteResult result = route.DriveTrain(train);

        // assert
        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void DriveTrain_SpeedMoreThanStationLimit_Fails()
    {
        // arrange
        var train = new Train(new Mass(100000), new Force(600000), new Time(0.1));
        var route = new Route(
            new Speed(200),
            new List<ITrackSection>
            {
                new MagneticForceTrack(new Length(4020), new Force(500000)),
                new Station(new Speed(200), new Time(120), new Time(120)),
                new MagneticNormalTrack(new Length(500)),
            });

        // act
        RouteResult result = route.DriveTrain(train);

        // assert
        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void DriveTrain_SpeedMoreThanRouteInStationLimit_Fails()
    {
        // arrange
        var train = new Train(new Mass(100000), new Force(600000), new Time(0.1));
        var route = new Route(
            new Speed(100),
            new List<ITrackSection>
            {
                new MagneticForceTrack(new Length(4010), new Force(500000)),
                new Station(new Speed(200), new Time(120), new Time(120)),
                new MagneticNormalTrack(new Length(500)),
            });

        // act
        RouteResult result = route.DriveTrain(train);

        // assert
        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void DriveTrain_CorrectAccelerationApproach_ImplementsSuccessfully()
    {
        // arrange
        var train = new Train(new Mass(100000), new Force(600000), new Time(0.1));
        var route = new Route(
            new Speed(100),
            new List<ITrackSection>
            {
                new MagneticForceTrack(new Length(4010), new Force(500000)),
                new MagneticNormalTrack(new Length(500)),
                new MagneticForceTrack(new Length(2995), new Force(-500000)),
                new Station(new Speed(100), new Time(120), new Time(120)),
                new MagneticNormalTrack(new Length(500)),
                new MagneticForceTrack(new Length(3005), new Force(500000)),
                new MagneticNormalTrack(new Length(500)),
                new MagneticForceTrack(new Length(2995), new Force(-500000)),
            });

        // act
        RouteResult result = route.DriveTrain(train);

        // assert
        Assert.IsType<RouteResult.Success>(result);
    }

    [Fact]
    public void DriveTrain_FirstTrackIsNormal_Fails()
    {
        // arrange
        var train = new Train(new Mass(100000), new Force(600000), new Time(0.1));
        var route = new Route(
            new Speed(100),
            new List<ITrackSection>
            {
                new MagneticNormalTrack(new Length(500)),
            });

        // act
        RouteResult result = route.DriveTrain(train);

        // assert
        Assert.IsType<RouteResult.Failure>(result);
    }

    [Fact]
    public void DriveTrain_StopBecauseOfNegativeAcceleration_Fails()
    {
        // arrange
        var train = new Train(new Mass(100000), new Force(600000), new Time(0.1));
        var route = new Route(
            new Speed(100),
            new List<ITrackSection>
            {
                new MagneticForceTrack(new Length(500), new Force(200000)),
                new MagneticForceTrack(new Length(500), new Force(-400000)),
            });

        // act
        RouteResult result = route.DriveTrain(train);

        // assert
        Assert.IsType<RouteResult.Failure>(result);
    }
}