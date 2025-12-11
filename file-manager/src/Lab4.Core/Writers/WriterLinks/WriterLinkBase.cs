namespace Itmo.ObjectOrientedProgramming.Lab4.Core.Writers.WriterLinks;

public abstract class WriterLinkBase : IWriterLink
{
    private IWriterLink? _next;

    public abstract IWriter? GetWriterByMode(string mode);

    public IWriterLink AddNext(IWriterLink link)
    {
        if (_next is null)
        {
            _next = link;
        }
        else
        {
            _next.AddNext(link);
        }

        return this;
    }

    protected IWriter? CallNext(string mode)
    {
        return _next?.GetWriterByMode(mode) ?? null;
    }
}