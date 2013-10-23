//Using delegates write a class Timer 
//that has can execute certain method at each t seconds.

using System;
using SimpleTimer;

class SimpleTimerCS
{
    static void Main()
    {
        //all time - 500m seconds... the interval - 50m sec
        //10 times executing the method
        Timer clock = new Timer(50, 500);
        clock.MethodsX = Print;
        clock.Execute();
    }

    private static void Print()
    {
        Console.WriteLine("Terrible Error!");
    }
}

