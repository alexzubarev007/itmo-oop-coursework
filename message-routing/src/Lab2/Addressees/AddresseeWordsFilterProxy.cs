using Itmo.ObjectOrientedProgramming.Lab2.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab2.Addressees;

public class AddresseeWordsFilterProxy : IAddressee
{
    private readonly IAddressee _addresseeNotifier;
    private readonly List<string> _forbiddenWords;

    public AddresseeWordsFilterProxy(IAddressee notifier, IEnumerable<string> forbiddenWords)
    {
        _addresseeNotifier = notifier;
        _forbiddenWords = forbiddenWords.ToList();
    }

    public void Accept(Message message)
    {
        foreach (string word in _forbiddenWords)
        {
            if (message.Header.Contains(word, StringComparison.OrdinalIgnoreCase) ||
                message.Body.Contains(word, StringComparison.OrdinalIgnoreCase))
            {
                _addresseeNotifier.Accept(message);
            }
        }
    }
}