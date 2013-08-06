//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System.Collections.Generic;
using System;

class BinRepresentationShort
{
    static void Main()
    {
        short number;
        do
        {
            Console.WriteLine("Set short number for representation: ");

        } while (!short.TryParse(Console.ReadLine(), out number));

        if (number < 0)
        {
            GetNegativeBinary(number);
        }
        else if (number > 0)
        {
            GetBinary(number);
        }
        else
        {
            Console.WriteLine("The number is zero");
        }
    }
    //method presentation negative binary
    private static void GetNegativeBinary(short number)
    {
        number++;
        for (int indexer = 15; indexer >= 0; indexer--)
        {
            short exponent = (short)Math.Pow(2, indexer);
            short digit = (short)(number / exponent);
            number = (short)(number % exponent);
            Console.Write(1+digit);
        }
    }

    //method presentation binary from first task
    private static void GetBinary(int a)
    {
        List<int> bin = new List<int>();
        while (a > 0)
        {
            bin.Add(a % 2);
            a = a / 2;

        }
        Console.WriteLine("The binary number is : ");
        for (int i = bin.Count - 1; i >= 0; i--)
        {
            Console.Write(bin[i]);
        }
        Console.WriteLine();
    }
}

