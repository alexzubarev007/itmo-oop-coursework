using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tables.Generators;

public sealed class CryptoRandom : IRandom
{
    public int Generate(int left, int right)
    {
        return RandomNumberGenerator.GetInt32(left, right);
    }
}