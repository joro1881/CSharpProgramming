//Write a program that generates and prints to the console 10 random values in the range [100, 200]

using System;

class TenRandomValues
{
    static void Main()
    {
        Console.WriteLine("Ten random values in the range [100,200]");
        byte min = 100;
        byte max = 200;
        GeneratingValues(min, max);
    }

    //logic
    private static void GeneratingValues(byte min, byte max)
    {
        Random rand = new Random();

        for (int index = 0; index < 10; index++)
        {
            Console.WriteLine("Random value {1} : {0}", rand.Next(min, max), index+1);
        }
    }
}

