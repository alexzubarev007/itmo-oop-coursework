namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterLinks;

public sealed class ConsoleWriterLink : WriterLinkBase
{
    public override IWriter? GetWriterByMode(string mode)
    {
        if (mode == "console")
        {
            return new ConsoleWriter();
        }

        return CallNext(mode);
    }
}