namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers;

public interface IWriterLink
{
    IWriter? GetWriterByMode(string mode);

    IWriterLink AddNext(IWriterLink link);
}