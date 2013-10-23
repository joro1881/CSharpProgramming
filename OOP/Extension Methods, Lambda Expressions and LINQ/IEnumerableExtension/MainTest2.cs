using IEnumerableExtension;
using System;

class MainTest2
{
    static void Main()
    {
        long[] seq = new long[20];
        for (int i = 0, k = 1; i < seq.Length; i++, k++)
        {
            seq[i] = k;
        }

        Console.WriteLine(seq.Min());
        Console.WriteLine(seq.Max());
        Console.WriteLine(seq.Average());
        Console.WriteLine(seq.Product());
        Console.WriteLine(seq.Sum());
    }
}

