using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Sections;

public interface ITrackSection
{
    SectionResult DriveSection(Train train);
}