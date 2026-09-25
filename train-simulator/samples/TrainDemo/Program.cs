using Itmo.ObjectOrientedProgramming.Lab1;
using Itmo.ObjectOrientedProgramming.Lab1.Parameters;
using Itmo.ObjectOrientedProgramming.Lab1.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Sections;
using System.Globalization;

namespace TrainDemo;

public static class Program
{
    public static void Main()
    {
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

        RouteResult result = route.DriveTrain(train);

        if (result is RouteResult.Success success)
        {
            string seconds = success.TotalTime.Value.ToString("F1", CultureInfo.InvariantCulture);
            Console.WriteLine($"Route completed in {seconds} seconds.");
        }
        else
        {
            Console.WriteLine($"Route failed: {result}");
        }
    }
}
