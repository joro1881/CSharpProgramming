using EventTimer;
using System;
using System.Linq;

class EventTest
{
    static void Main()
    {
        EvTimer printing = new EvTimer();
        printing.methodX += Print;
        printing.Start(1000);

        Console.WriteLine("Press enter to stop the program!");
        Console.ReadLine();
    }

    public static void Print()
    {
        Console.WriteLine("Fatal error");
    }
}

